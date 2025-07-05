namespace Domain.CartService;

public interface ICartRepository
{
    public IEnumerable<Cart> GetAllCarts();
    public Cart GetCartById(Guid cartId);
    public void AddCart(Cart cart);
    public void UpdateCart(Cart cart);
    public void DeleteCart(Guid cartId);
}