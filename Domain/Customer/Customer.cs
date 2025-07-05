namespace Domain.Customer;

public class Customer
{
    private Guid Id = new Guid();
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
}