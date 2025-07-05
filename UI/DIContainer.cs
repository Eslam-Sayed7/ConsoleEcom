using ConsoleEcomm.Printer;

using DataAccess;
using Domain.CartService;
using Domain.Customer;
using Domain.Product;
using Domain.ShippingService;

namespace ConsoleEcomm;

public class DIContainer
{
    /// <summary>
    /// this simulates a dependency injection container.
    /// we register our dependencies here manually and resolve them 
    /// </summary>
    
    //Todo: why readonly can usercontext be chanaged with every user ?
    public  IProductRepository _productRepository;
    public ICustomerContextRepository CustomerContextRepository;
    public  IProductService _productService;
    public  ICartService _cartService;
    public readonly ICartRepository _cartRepository;
    public readonly IShippingService _shippingService;
    public readonly IPrinter _printer;
    
    public DIContainer()
    {
        CustomerContextRepository = new CustomerContextRepository();
        _cartRepository = new CartRepository();
        _productRepository = new ProductRepository();
        _productService = new ProductService( _productRepository );
        _shippingService =  new ShippingService();
        _cartService = new CartService(_cartRepository);
        _printer = new ConsolePrinter();
    }
}