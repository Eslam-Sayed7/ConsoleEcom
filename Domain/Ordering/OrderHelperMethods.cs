namespace Domain.Ordering;

public static class OrderHelperMethods
{
    public static void GetOrderDetails(Order order )
    {
        foreach (var item in order.GetOrderItems())
        {
            if (item == null)
            {
                Console.WriteLine("Order item is null.");
                return;
            }

            Console.WriteLine(
                $"Product ID: {item.OrderItemName}, Quantity: {item.GetQuantity()}, Total Price: {item.TotalPrice}");
        }
    }
    
    
}