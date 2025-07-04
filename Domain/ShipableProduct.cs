namespace Domain;

public class ShipableProduct : Product , IShipable
{
    public string GetName() => Name;
    public double GetWeight() => UnitPrice * Quantity; 
}