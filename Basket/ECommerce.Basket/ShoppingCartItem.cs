namespace ECommerce.Basket;

public class ShoppingCartItem
{
    private readonly long _productId;
    private int _quantity;

    public ShoppingCartItem(long productId)
    {
        _productId = productId;
        _quantity = 1;
    }

    public ShoppingCartItem(long productId, int quantity)
    {
        _productId = productId;
        _quantity = quantity;
    }

    internal int Quantity => _quantity;
    internal void IncreaseQuantity(int quantity = 1) => _quantity += quantity;

    internal bool IsEqualsProduct(long productId) => _productId == productId;

    internal bool IsEqualsProduct(ShoppingCartItem cartItem) => _productId == cartItem._productId;
}