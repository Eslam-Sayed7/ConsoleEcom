namespace Domain.Product;

public class ExpirableProduct : Product , IExpirable
{
    public DateTime ExpirationDate { get; }
    public DateTime GetExpirationDate() => ExpirationDate;
    public ExpirableProduct(string name, double unitPrice, int quantity, DateTime expirationDate) 
        : base(name, unitPrice, quantity)
    {
        if (expirationDate < DateTime.Now) throw new ArgumentOutOfRangeException(nameof(expirationDate), "Expiration date cannot be in the past.");
        ExpirationDate = expirationDate;
    }
}