namespace Domain.Product;

public abstract class Product
{
    protected int Id;
    protected string Name; 
    protected double UnitPrice; 
    protected int Quantity;

    public double GetPrice() => UnitPrice;
    public int GetId() => Id;
    public int GetQuantity() => Quantity;
    public void SetQuantity(int quantity)
    {
        if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");
        Quantity = quantity;
    }
    protected Product(int id ,string name, double unitPrice, int quantity = 1)
    {
        ArgumentNullException.ThrowIfNull(name);
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price cannot be negative.");
        Id = id;
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

}