using System.Reflection.Metadata.Ecma335;
using ConsoleEcomm.Printer;
using Domain;
using Domain.CartService;
using Domain.Customer;
using Domain.Ordering;

namespace ConsoleEcomm;

public class HomePage
{
    private readonly DIContainer _services;

    public HomePage(DIContainer services)
    {
        ArgumentNullException.ThrowIfNull(services);
        _services = services;
        ArgumentNullException.ThrowIfNull(services._productRepository);
        ArgumentNullException.ThrowIfNull(services._productService);
        ArgumentNullException.ThrowIfNull(services._shippingService);
        ArgumentNullException.ThrowIfNull(services._cartRepository);
        ArgumentNullException.ThrowIfNull(services._cartService);
    }

    public void ListProducts()
    {
        var printMessage = new PrintMessage();
        var shippable = _services._productService.GetShippableProducts();
        var shippableExpirableProducts = _services._productService.GetShippableExpirableProducts();
        var expirableProducts = _services._productService.GetExpirableProducts();

        printMessage.AddMessage("Available Products:");
        printMessage.AddMessage("ProductId - ProdcutName - Price - Available:");
        
        foreach (var product in shippableExpirableProducts)
        {
            if (product.GetQuantity() > 0)
                printMessage.AddMessage($"{product.GetId()}  -  {product.GetName()} (${product.GetPrice()}) - {product.GetQuantity()}");
        }
        foreach (var product in shippable)
        {
            if (product.GetQuantity() > 0)
                printMessage.AddMessage($"{product.GetId()}  -  {product.GetName()} (${product.GetPrice()}) - {product.GetQuantity()}");
        }
        foreach (var product in expirableProducts)
        {
            if(product.GetQuantity() > 0)
                printMessage.AddMessage($"{product.GetId()}  -  {product.GetName()} (${product.GetPrice()}) - {product.GetQuantity()}");
        }
        _services._printer.PrintMessages(printMessage);
    }

    public Customer MakeCustomer()
    {
        string customerName = string.Empty;
        double customerBalance = 0.0;
        string customerAddress = string.Empty;
        
        while (true)
        {
            do {
                Console.WriteLine("Please enter your name:");
                customerName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(customerName));

            do
            {
                Console.WriteLine("Please enter your balance (must be a positive number):");
            } while (!double.TryParse(Console.ReadLine(), out customerBalance) || customerBalance < 0);

            do
            {
                Console.WriteLine("Please enter your address:");
                customerAddress = Console.ReadLine();
            } while(string.IsNullOrWhiteSpace(customerAddress));
            break;
        }
        var customer = new Customer(customerBalance, customerAddress, customerName );
        return customer;
    }
    
    public Order MakeOrder()
    {
        var order = new Order();
        do
        {
            Console.WriteLine("Please enter the product ID to add to your order (or type 'done' to finish):");
            var input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
            if (input?.ToLower() == "done")
            {
                if (order.GetOrderItems().Count == 0)
                {
                    Console.WriteLine("No items added to the order. Exiting order creation.");
                    return null;
                }
                break;
            }
            if (int.TryParse(input, out int productId))
            {
                var available = _services._productService.GetProductCount(productId);
                var orderItem = _services._productService.GetProductById(productId);
                
                if (orderItem != null)
                {
                    Console.WriteLine("How many of this product would you like to add?");
                    int quantity;
                    while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0 ||
                           quantity > available)
                    {
                        if (quantity <= 0)
                        {
                            Console.WriteLine("Invalid input. Please enter a positive integer for the quantity.");
                        }
                        else if (quantity >= available)
                        {
                            Console.WriteLine(
                                $"Insufficient stock. Available quantity is {available}. Please enter a valid quantity.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a positive integer for the quantity.");
                        }
                    }
                    // atomic
                    orderItem.SetQuantity(quantity);
                    order.AddOrderItem(orderItem);
                    _services._productService.UpdateProductQuantity(productId, available - quantity );
                    Console.WriteLine($"Added {orderItem.GetName()} to your order.");
                }
                else
                {
                    Console.WriteLine("Product not found. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid product ID or 'done'.");
            }
            
        } while (true);
        return order;
    }
    public UserContext MakeCustomerCartContext()
    {
        var customer = MakeCustomer();
        var order = MakeOrder();
        if (order == null)
        {
            return null;
        }
        var cart = new Cart(customer.GetCustomerId() ,order );
        customer.UpdateBalance(-1 * cart.GetTotalPrice());
        _services._cartRepository.AddCart(cart);
        var cntxt = new UserContext(customer, cart);
        _services.CustomerContextRepository.AddCustomer(cntxt);
        return cntxt;
    }

    public void PrintCartSummary( )
    {
        Cart cart;
        Console.WriteLine("write cart id to print summary");
        
        var input = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(input) || !Guid.TryParse(input, out Guid cartId))
        {
            Console.WriteLine("Invalid cart ID.");
            input = Console.ReadLine();
        } 
        cart = _services._cartRepository.GetCartById(Guid.Parse(input));
        Console.WriteLine("Cart not found.");
        
        if(cart.order == null || cart.order.GetOrderItems().Count == 0)
        {
            Console.WriteLine("Cart is empty.");
            return;
        }
        Console.WriteLine($"Cart ID: {cart.GetCartId()}");
        Console.WriteLine($"** shipment Notice **");
        double totalWeight = 0 , totalPrice = 0 , shippingPrice = 0;
        
        foreach (var item in cart.GetOrder().GetOrderItems())
        {
            if (item.IsShippable)
            {
                Console.WriteLine($"{item.GetQuantity()}X {item.GetName()}, , weight: {item.GetWeight() * item.GetQuantity()} g");
                totalWeight += item.GetWeight() * item.GetQuantity();
            }
        }
        
        Console.WriteLine($"Total Weight: {totalWeight} g");
        shippingPrice = totalWeight / 1000 * 5; // Note: 5$ per kg
        foreach (var item in cart.GetOrder().GetOrderItems())
        {
            Console.WriteLine($"{item.GetQuantity()}X {item.GetName()}, , Price: ${item.TotalPrice()}");
            totalPrice += item.TotalPrice();
        }
        Console.WriteLine($"-----------------------");
        Console.WriteLine($"Subtotal: {totalPrice}");
        Console.WriteLine($"Shipping: { shippingPrice}");    // Note: 5$ per kg
        totalPrice += shippingPrice;
        Console.WriteLine($"Total Price: ${totalPrice}");
        
    }
    public void ViewCarts()
    {
        var customerContexts = _services.CustomerContextRepository.GetAllCustomers();
       Console.WriteLine("Available Carts:");
        
        foreach (var ctx in customerContexts)
        {
            Console.WriteLine($"userId: {ctx.GetUserId()}  - CartId: {ctx.GetCart().GetCartId()}");
        }
    }
    public void ViewCustomers()
    {
        var printMessage = new PrintMessage();
        var customerContexts = _services.CustomerContextRepository.GetAllCustomers();
        printMessage.AddMessage("Available Customers:");
        printMessage.AddMessage("CustomerId - Name - Balance - Address");
        
        foreach (var ctx in customerContexts)
        {
            printMessage.AddMessage($"{ctx.GetUserId()}  -  {ctx.GetUserName()} (${ctx.GetUserBalance()}) - {ctx.GetUserAddress()}");
        }
        _services._printer.PrintMessages(printMessage);
    }

 public void ViewShippings()
    {
        var carts = _services._cartRepository.GetAllCarts();
        var shippableOrders = new List<OrderItem>();
        foreach (var cart in carts)
        {
            shippableOrders.AddRange(cart.order.GetOrderItems().Where(item => item.IsShippable));
        }
        _services._shippingService.ShipOrders(shippableOrders);
    }

}