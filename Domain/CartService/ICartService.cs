namespace Domain.CartService;

public interface ICartService 
{
    IEnumerable<Cart> GetCarts();
    Cart GetCart(Guid cartId);
    void AddCart(Cart cart);
    void RemoveCart(Cart cart);
    
}