namespace Domain.Product;

public abstract class Product
{
    protected string Name; 
    protected double UnitPrice; 
    protected int Quantity;

    protected Product(string name, double unitPrice, int quantity = 1)
    {
        ArgumentNullException.ThrowIfNull(name);
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price cannot be negative.");
        
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

}