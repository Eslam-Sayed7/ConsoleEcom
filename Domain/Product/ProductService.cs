using System.Collections;
using DataAccess;
using Domain.Customer;
using Domain.Ordering;

namespace Domain.Product;

public class ProductService : IProductService 
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        ArgumentNullException.ThrowIfNull(productRepository);
        _productRepository = productRepository;
    }

    public IEnumerable<ShippableExpirableProduct> GetShippableExpirableProducts() =>
        _productRepository.GetShippableExpirableProducts();

    public IEnumerable<ShippableProduct> GetShippableProducts() =>
        _productRepository.GetShippableProducts();

    public IEnumerable<ExpirableProduct> GetExpirableProducts() 
        => _productRepository.GetExpirableProducts();

    public OrderItem GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public bool UpdateProductQuantity(int productId, int quantity)
    {
        if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");
        return _productRepository.UpdateProductQuantity(productId, quantity);
    }

    public int GetProductCount(int id)
    {
        if (id < 0) throw new ArgumentOutOfRangeException(nameof(id), "Invalid product ID");
        return _productRepository.GetProductCount(id);
    }
}