using System.Collections;
using DataAccess;
using Domain.Customer;

namespace Domain.Product;

public class ProductService : IProductService 
{
    private readonly IProductRepository _productRepository;
    private readonly IUserContext _userContext;

    public ProductService(IUserContext userContext, IProductRepository productRepository)
    {
        ArgumentNullException.ThrowIfNull(userContext);
        ArgumentNullException.ThrowIfNull(productRepository);
        _userContext = userContext;
        _productRepository = productRepository;
    }

    public IEnumerable<ShippableExpirableProduct> GetShippableExpirableProducts() =>
        _productRepository.GetShippableExpirableProducts();

    public IEnumerable<ShippableProduct> GetShippableProducts() =>
        _productRepository.GetShippableProducts();

    public IEnumerable<ExpirableProduct> GetExpirableProducts() 
        => _productRepository.GetExpirableProducts();

    // public IEnumerable<Product> ListProducts()
    // {
    //     var shippable = _productRepository.GetShippableProducts();
    //     var shippableExpirableProducts = _productRepository.GetShippableExpirableProducts();
    //     var expirableProducts = _productRepository.GetExpirableProducts();
    // }
    public void Initialize()
    {
    }
}