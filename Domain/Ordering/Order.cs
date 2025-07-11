namespace Domain.Ordering;

public class Order
{
    private IList<OrderItem> _items = new List<OrderItem>();

    public void AddOrderItem(OrderItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Order item cannot be null.");

        _items.Add(item);
    }
    public IList<OrderItem> GetOrderItems()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("No items in the order.");
            return null;
        }

        return _items;
    }
}