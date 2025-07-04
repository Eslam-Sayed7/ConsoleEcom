namespace Domain;

public class ExpirableProduct : Product , IExpirable
{
    public DateTime ExpirationDate { get; }
}