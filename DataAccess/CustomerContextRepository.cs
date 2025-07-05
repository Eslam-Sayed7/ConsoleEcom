using Domain.Customer;

namespace DataAccess;

public class CustomerContextRepository : ICustomerContextRepository
{
    private readonly List<UserContext> _customers = new List<UserContext>();
    
    public IEnumerable<UserContext> GetAllCustomers() =>  _customers;
    public void AddCustomer(UserContext customer) => _customers.Add(customer);

}