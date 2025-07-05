namespace Domain.Product;

public class ShippableExpirableProduct : ShippableProduct, IExpirable
{
    private DateTime ExpirationDate; 
    public DateTime GetExpirationDate () => ExpirationDate; // override
    
    public ShippableExpirableProduct(int id , string name, double unitPrice, int quantity, DateTime expirationDate, double weight = 0.0)
        : base(id ,name, unitPrice , quantity , weight)
    {
        ExpirationDate = expirationDate;
    }
}