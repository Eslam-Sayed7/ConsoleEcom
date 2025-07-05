using Domain.CartService;

namespace DataAccess;

public class CartRepository : ICartRepository
{
    private readonly List<Cart> _carts = new List<Cart>();

    public Cart GetCartById(Guid cartId)
    {
        return _carts.FirstOrDefault(c => c.Id == cartId);
    }

    public void AddCart(Cart cart)
    {
        _carts.Add(cart);
    }

    public void UpdateCart(Cart cart)
    {
        var existingCart = GetCartById(cart.Id);
        if (existingCart != null)
        {
            existingCart.UserId = cart.UserId;
            existingCart.order = cart.order;
        }
    }
    
    public void DeleteCart(Guid cartId)
    {
        var cart = GetCartById(cartId);
        if (cart != null)
        {
            _carts.Remove(cart);
        }
    }
    
}