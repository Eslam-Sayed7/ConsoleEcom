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
}