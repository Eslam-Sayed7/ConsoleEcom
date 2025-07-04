namespace Domain.Product;

public interface IProductService
{
    IEnumerable<ShippableExpirableProduct> GetShippableExpirableProducts();
    IEnumerable<ShippableProduct> GetShippableProducts();
    IEnumerable<ExpirableProduct> GetExpirableProducts();
}