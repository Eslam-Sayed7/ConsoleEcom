using Domain.Ordering;

namespace Domain.Product;

public interface IProductService
{
    IEnumerable<ShippableExpirableProduct> GetShippableExpirableProducts();
    IEnumerable<ShippableProduct> GetShippableProducts();
    IEnumerable<ExpirableProduct> GetExpirableProducts();
    OrderItem GetProductById(int id);
    bool UpdateProductQuantity(int productId, int quantity);
    int GetProductCount(int id);
}