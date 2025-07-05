namespace Domain.CartService;

public class CartService : ICartService
{
    private ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        ArgumentNullException.ThrowIfNull(cartRepository);
        _cartRepository = cartRepository;
    }
    public IEnumerable<Cart> GetCarts() => _cartRepository.GetAllCarts();
    public Cart GetCart( Guid cartId) => _cartRepository.GetCartById( cartId);
    public void AddCart(Cart cart) 
    {
        _cartRepository.AddCart(cart);
    }
    public void RemoveCart(Cart cart)
    {
        _cartRepository.DeleteCart(cart.Id);
    }
}