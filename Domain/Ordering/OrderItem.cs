namespace Domain.Ordering;

public class OrderItem
{
    private readonly string _orderItemName;
    private readonly double _unitPrice;
    private int _quantity; 
    
    public OrderItem( Guid orderId, string orderName , double unitPrice, int quantity = 0)
    {
        _quantity = quantity >= 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");
        _orderItemName = orderName ?? throw new ArgumentNullException(nameof(orderName), "Order name cannot be null.");
        _unitPrice = unitPrice;
    }
    
    public void SetQuantity(int quantity) => _quantity = quantity;
    public int GetQuantity() => _quantity;
    public string OrderItemName => _orderItemName;
    public double TotalPrice => _unitPrice * _quantity;
}
