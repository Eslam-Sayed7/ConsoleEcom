namespace Domain.Ordering;

public class OrderItem
{
    private readonly string _orderItemName;
    private readonly double _unitPrice;
    private int _quantity; 
    private bool _isShippable;
    double _weight;
    
    public OrderItem( Guid orderId, string orderName , double unitPrice,  bool isShippable, int quantity = 0 )
    {
        _quantity = quantity >= 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");
        _orderItemName = orderName ?? throw new ArgumentNullException(nameof(orderName), "Order name cannot be null.");
        _unitPrice = unitPrice;
        _isShippable = isShippable;
    }
    
    public void SetQuantity(int quantity) => _quantity = quantity;
    public int GetQuantity() => _quantity;
    public string OrderItemName => _orderItemName;
    public bool IsShippable => _isShippable; 

    public double TotalPrice()
    {
        double total = 0;
        total += _unitPrice * _quantity;
        return total;
    } 
    public void SetWeight(double weight)
    {
        if (weight < 0) throw new ArgumentOutOfRangeException(nameof(weight), "Weight cannot be negative.");
        _weight = weight; 
    }
    public double GetWeight() => _weight;
}
