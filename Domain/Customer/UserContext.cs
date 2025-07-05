using Domain.CartService;

namespace Domain.Customer;

public class UserContext : IUserContext
{
   private Customer customer;
   private Cart cart;

   public UserContext(Customer customer, Cart cart)
   {
      this.customer = customer;
      this.cart = cart;
   }
   public Guid GetUserId() => customer.GetCustomerId();
    public string GetUserName() => customer.GetCustomerName();
    public double GetUserBalance() => customer.GetCustomerBalance();
    public string GetUserAddress() => customer.GetCustomerAddress();
    public Cart GetCart() => cart;
    public Guid GetCartId() => cart.GetCartId();
    
}