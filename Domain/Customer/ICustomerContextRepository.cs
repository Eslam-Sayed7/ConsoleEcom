namespace Domain.Customer;

public interface ICustomerContextRepository
{
    IEnumerable<UserContext> GetAllCustomers();
    void AddCustomer(UserContext customer);
    
}