using ConsoleEcomm.Printer;

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
        ArgumentNullException.ThrowIfNull(services._userContext);
    }

    public void ListProducts()
    {
        var printMessage = new PrintMessage();
        var shippable = _services._productService.GetShippableProducts();
        var shippableExpirableProducts = _services._productService.GetShippableExpirableProducts();
        var expirableProducts = _services._productService.GetExpirableProducts();

        printMessage.AddMessage("Available Products:");
        foreach (var product in shippable)
        {
            printMessage.AddMessage($"- {product.GetName()} (${product.GetPrice()})");
        }
        foreach (var product in shippableExpirableProducts)
        {
            printMessage.AddMessage($"- {product.GetName()} (${product.GetPrice()})");
        }
        foreach (var product in expirableProducts)
        {
            printMessage.AddMessage($"- {product.GetName()} (${product.GetPrice()})");
        }
        printMessage.Print();
    }

    public void PrintCustomerCart()
    {
    }

    public void PrintOrderSummary()
    {
        
    }
    public void PrintShippingOptions()
    {
    }

}