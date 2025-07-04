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
    public IUserContext _userContext;
    public readonly IProductRepository _productRepository;
    public readonly IProductService _productService;
    public readonly IShippingService _shippingService;
    public readonly ICartService _cartService;
    public readonly IPrinter _printer;
    
    public DIContainer()
    {
        _userContext = new UserContext();
        _productRepository = new ProductRepository();
        _productService = new ProductService(_userContext, _productRepository );
        _shippingService =  new ShippingService();
        _cartService = new CartService();
        _printer = new ConsolePrinter();
    }
}