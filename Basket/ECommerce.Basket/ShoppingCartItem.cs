using ECommerce.Share.Abstractions;

namespace ECommerce.Basket;

public class ShoppingCartItem : ISnapshot<ShoppingCartItemSnapshot>
{
    private readonly long _productId;

    public ShoppingCartItem(long productId)
    {
        _productId = productId;
        Quantity = 1;
    }

    public ShoppingCartItem(long productId, int quantity)
    {
        _productId = productId;
        Quantity = quantity;
    }

    internal int Quantity { get; private set; }

    public ShoppingCartItemSnapshot TakeSnapshot()
    {
        return new(_productId, Quantity);
    }

    internal void IncreaseQuantity(int quantity = 1)
    {
        Quantity += quantity;
    }

    internal bool IsEqualsProduct(long productId)
    {
        return _productId == productId;
    }

    internal bool IsEqualsProduct(ShoppingCartItem cartItem)
    {
        return _productId == cartItem._productId;
    }
}