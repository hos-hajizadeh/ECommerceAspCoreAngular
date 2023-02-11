using ECommerce.Share.Abstractions;

namespace ECommerce.Basket;

public class ShoppingCart : ISnapshot<ShoppingCartSnapshot>
{
    private readonly long _userId;
    private readonly HashSet<ShoppingCartItem> _items = new();

    public ShoppingCart(long userId)
    {
        _userId = userId;
    }

    public void Add(long productId, int quantity = 1)
    {
        var existsItem = _items.FirstOrDefault(c => c.IsEqualsProduct(productId));
        if (existsItem != null)
            existsItem.IncreaseQuantity(quantity);
        else
        {
            var item = new ShoppingCartItem(productId, quantity);
            _items.Add(item);
        }
    }

    public void Remove(long productId)
    {
        _items.RemoveWhere(c => c.IsEqualsProduct(productId));
    }

    public void Remove(ShoppingCartItem cartItem)
    {
        _items.Remove(cartItem);
    }

    public void Clear()
    {
        _items.Clear();
    }

    public int? GetProductQuantity(long productId)
    {
        return _items.FirstOrDefault(c => c.IsEqualsProduct(productId))?.Quantity;
    }
    
    public ShoppingCartSnapshot TakeSnapshot()
    {
        return new ShoppingCartSnapshot(_userId, _items.Select(item => item.TakeSnapshot()));
    }
}