namespace Domain.Product;

public class ShippableProduct : Product , IShipable
{
    private readonly double Weight; 
    public bool Shippable = true;
    public string GetName() => Name;
    public double GetWeight() => Weight ; // override 
    public ShippableProduct(string name, double unitPrice, int quantity , double weight) : base(name, unitPrice , quantity)
    {
        Weight = weight;
    }
}