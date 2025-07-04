using Domain.Product;

namespace DataAccess;

public interface IProductRepository
{
    public IEnumerable<ShippableExpirableProduct> GetShippableExpirableProducts();
    public IEnumerable<ShippableProduct> GetShippableProducts();
    public IEnumerable<ExpirableProduct> GetExpirableProducts();
}