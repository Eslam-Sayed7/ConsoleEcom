using Domain.Ordering;

namespace Domain.Product;

public static class OrderItemMakerExtension
{
    public static OrderItem ToOrderItem(ExpirableProduct product , int quantity = 0)
    {
        if (product == null) throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        var orderitem =  new OrderItem(Guid.NewGuid(), product.GetName(), product.GetPrice() , false , quantity);
        return orderitem;
    }
    public static OrderItem ToOrderItem(ShippableProduct product, int quantity = 0)
    {
        if (product == null) throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        var orderitem = new OrderItem(Guid.NewGuid(), product.GetName(), product.GetPrice(), true, quantity);
        orderitem.SetWeight(product.GetWeight());
        return orderitem;
    }
    public static OrderItem ToOrderItem(ShippableExpirableProduct product, int quantity = 0)
    {
        if (product == null) throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        var orderItem = new OrderItem(Guid.NewGuid(), product.GetName(), product.GetPrice(), true ,quantity);
        orderItem.SetWeight(product.GetWeight());
        return orderItem;
    }
    
}