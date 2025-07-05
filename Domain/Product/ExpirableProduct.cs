namespace Domain.Product;

public class ExpirableProduct : Product , IExpirable 
{
    public DateTime ExpirationDate { get; }
    public DateTime GetExpirationDate() => ExpirationDate;
    public string GetName() => Name;
    public ExpirableProduct(int id , string name, double unitPrice, int quantity, DateTime expirationDate) 
        : base(id , name, unitPrice, quantity)
    {
        if (expirationDate < DateTime.Now) throw new ArgumentOutOfRangeException(nameof(expirationDate), "Expiration date cannot be in the past.");
        ExpirationDate = expirationDate;
    }
}