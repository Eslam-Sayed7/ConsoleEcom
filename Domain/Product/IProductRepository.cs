using Domain.Ordering;
using Domain.Product;

namespace DataAccess;

public interface IProductRepository
{
    public IEnumerable<ShippableExpirableProduct> GetShippableExpirableProducts();
    public IEnumerable<ShippableProduct> GetShippableProducts();
    public IEnumerable<ExpirableProduct> GetExpirableProducts();
    public OrderItem GetProductById(int id);
    public bool UpdateProductQuantity(int productId, int quantity);
    public int GetProductCount(int id);
}