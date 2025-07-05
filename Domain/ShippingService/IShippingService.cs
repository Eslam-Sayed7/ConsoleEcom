using Domain.Ordering;

namespace Domain.ShippingService;

public interface IShippingService
{
    public void ShipOrders(IList<OrderItem> shipablOrders);

}