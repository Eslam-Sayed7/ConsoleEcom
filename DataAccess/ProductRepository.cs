using System.Diagnostics.CodeAnalysis;
using Domain;
using Domain.Ordering;
using Domain.Product;

namespace DataAccess;

public class ProductRepository : IProductRepository
{

    private Dictionary<int, ShippableExpirableProduct> _shippableExpirableProducts = new()
    {
        { 1, new ShippableExpirableProduct(1, "Milk", 1.5, 10, DateTime.Now.AddDays(7), 1.0) },
        { 2, new ShippableExpirableProduct(2, "Bread", 2.0, 5, DateTime.Now.AddDays(3), 0.5) },
        { 3, new ShippableExpirableProduct(3, "Eggs", 3.0, 12, DateTime.Now.AddDays(10), 0.2) }
    };

    private Dictionary<int, ShippableProduct> _shippableProducts = new()
    {
        { 4, new ShippableProduct(4, "Laptop", 1000.0, 1, 2.5) },
        { 5, new ShippableProduct(5, "Smartphone", 800.0, 1, 0.3) },
        { 6, new ShippableProduct(6, "Headphones", 150.0, 1, 0.2) }
    };
    
    private Dictionary<int ,ExpirableProduct> _expirableProducts = new ()
    {
        { 7, new ExpirableProduct(7, "Cheese", 5.0, 8, DateTime.Now.AddDays(14)) },
        { 8, new ExpirableProduct(8, "Yogurt", 1.0, 6, DateTime.Now.AddDays(5)) },
        { 9, new ExpirableProduct(9, "Butter", 2.5, 4, DateTime.Now.AddDays(10)) }
    };

    public ProductRepository()
    {
    }

    public IEnumerable<ShippableExpirableProduct> GetShippableExpirableProducts() =>  _shippableExpirableProducts.Values;
    public IEnumerable<ShippableProduct> GetShippableProducts() => _shippableProducts.Values;
    public IEnumerable<ExpirableProduct> GetExpirableProducts() => _expirableProducts.Values;
    
    public OrderItem GetProductById(int id)
    {
        if (id < 0 )
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid product ID");

        _shippableExpirableProducts.TryGetValue(id , out var  prod1 );
        if (prod1 != null && prod1.GetQuantity() > 0)
        {
            return OrderItemMakerExtension.ToOrderItem(prod1, 1);
        }
        _expirableProducts.TryGetValue(id , out var prod2 );
        if (prod2 != null && prod2.GetQuantity() > 0)
        {
            return OrderItemMakerExtension.ToOrderItem(prod2, 1);
        }
        _shippableProducts.TryGetValue(id , out var prod3 );
        if (prod3 != null && prod3.GetQuantity() > 0)
        {
            return OrderItemMakerExtension.ToOrderItem(prod3, 1);
        }
        return null;
    }
    public bool UpdateProductQuantity(int id, int quantity)
    {
        if (id < 0 )
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid product ID");
        if (quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than or equal to zero.");

        _shippableExpirableProducts.TryGetValue(id , out var  prod1 );
        if (prod1 != null)
        {
            prod1.SetQuantity(quantity);
            _shippableExpirableProducts[id] = prod1; 
            return true;
        }
        _expirableProducts.TryGetValue(id , out var prod2 );
        if (prod2 != null)
        {
            prod2.SetQuantity(quantity);
            _expirableProducts[id] = prod2;
            return true;
        }
        _shippableProducts.TryGetValue(id , out var prod3 );
        if (prod3 != null)
        {
            prod3.SetQuantity(quantity);
            _shippableProducts[id] = prod3;
            return true;
        }
        return false;
    }
    
    public int GetProductCount(int id)
    {
        if (id < 0 )
            throw new ArgumentOutOfRangeException(nameof(id), "Invalid product ID");

        _shippableExpirableProducts.TryGetValue(id , out var  prod1 );
        if (prod1 != null && prod1.GetQuantity() > 0)
        {
            return prod1.GetQuantity();
        }
        _expirableProducts.TryGetValue(id , out var prod2 );
        if (prod2 != null && prod2.GetQuantity() > 0)
        {
            return prod2.GetQuantity();
        }
        _shippableProducts.TryGetValue(id , out var prod3 );
        if (prod3 != null && prod3.GetQuantity() > 0)
        {
            return prod3.GetQuantity();
        }
        return 0;
    }
}