using Domain;
using Domain.Product;

namespace DataAccess;

public class ProductRepository
{
    private IList<ShippableExpirableProduct> _shippableExpirableProducts = new List<ShippableExpirableProduct>()
    {
        new ShippableExpirableProduct("Milk", 1.5, 10, DateTime.Now.AddDays(7), 1.0),
        new ShippableExpirableProduct("Bread", 2.0, 5, DateTime.Now.AddDays(3), 0.5),
        new ShippableExpirableProduct("Eggs", 3.0, 12, DateTime.Now.AddDays(10), 0.2)
    };
    private IList<ShippableProduct> _shippableProducts = new List<ShippableProduct>()
    {
        new ShippableProduct("Laptop", 1000.0, 1, 2.5),
        new ShippableProduct("Smartphone", 800.0, 1, 0.3),
        new ShippableProduct("Headphones", 150.0, 1, 0.2)
    };
    
    private IList<ExpirableProduct> _expirableProductsproducts = new List<ExpirableProduct>()
    {
        new ExpirableProduct("Canned Beans", 1.0, 20, DateTime.Now.AddYears(2)),
        new ExpirableProduct("Pasta", 0.5, 50, DateTime.Now.AddYears(3)),
        new ExpirableProduct("Rice", 0.8, 30, DateTime.Now.AddYears(4))
    };
    
    public IEnumerable<ShippableExpirableProduct> GetShippableExpirableProducts() => _shippableExpirableProducts;
    public IEnumerable<ShippableProduct> GetShippableProducts() => _shippableProducts;
    public IEnumerable<ExpirableProduct> GetExpirableProducts() => _expirableProductsproducts;
}