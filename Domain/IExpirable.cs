namespace Domain;

public interface IExpirable
{
    public DateTime ExpirationDate { get; }
    public DateTime GetExpirationDate()
    {
        return ExpirationDate;
    }
}