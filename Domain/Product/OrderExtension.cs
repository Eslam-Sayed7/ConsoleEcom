using Domain.Ordering;

namespace Domain.Product;

public static class OrderItemMakerExtension
{
    public static OrderItem ToOrderItem(ExpirableProduct product , int quantity = 0)
    {
        if (product == null) throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        return new OrderItem(Guid.NewGuid(), product.GetName(), product.GetPrice(), quantity);
    }
    public static OrderItem ToOrderItem(ShippableProduct product, int quantity = 0)
    {
        if (product == null) throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        return new OrderItem(Guid.NewGuid(), product.GetName(), product.GetPrice(), quantity);
    }
    public static OrderItem ToOrderItem(ShippableExpirableProduct product, int quantity = 0)
    {
        if (product == null) throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        return new OrderItem(Guid.NewGuid(), product.GetName(), product.GetPrice(), quantity);
    }
    
}