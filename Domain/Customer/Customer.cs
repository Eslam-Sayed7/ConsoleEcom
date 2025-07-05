namespace Domain.Customer;

public class Customer
{
    private Guid Id = Guid.NewGuid(); 
    private string CustomerName;
    private double Balance;
    private string Address;

    public Customer(double balance, string address, string customerName)
    {
        Balance = balance;
        Address = address;
        CustomerName = customerName;
    }
    public Guid GetCustomerId() => Id;
    public string GetCustomerName() => CustomerName;
    public double GetCustomerBalance() => Balance;
    public string GetCustomerAddress() => Address;
    public void UpdateBalance(double amount)
    {
        if (amount < 0 && Math.Abs(amount) > Balance)
            throw new InvalidOperationException("Insufficient balance for this operation.");
        Balance += amount;
    }
}