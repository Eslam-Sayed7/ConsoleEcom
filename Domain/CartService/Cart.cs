using Domain.Ordering;
namespace Domain.CartService;

public class Cart
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Order order { get; set; }

    public Cart(Guid userId, Order order)
    {
            UserId = userId;
            this.order = order;
    }
    public Guid GetCartId() => Id;
    public Order GetOrder() => order;
    
    public double GetTotalPrice()
    {
        if (order == null || order.GetOrderItems() == null)
            return 0;
        return order.GetOrderItems().Sum(item => item.TotalPrice());
    }
    
}