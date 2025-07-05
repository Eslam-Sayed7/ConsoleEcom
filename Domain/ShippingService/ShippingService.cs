using Domain.Ordering;

namespace Domain.ShippingService;

public  class ShippingService : IShippingService 
{
    public void ShipOrders(IList<OrderItem> shipablOrders ) 
    {
        if (shipablOrders == null || shipablOrders.Count == 0)
        {
            Console.WriteLine("No orders to ship.");
        }
        
        foreach (var order in shipablOrders)
        {
            Console.WriteLine($"Shipping order with weight : {order.GetWeight()} - with name {order.GetName()}");
        }
        
    }
}