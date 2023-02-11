namespace ECommerce.Basket.Test;

public class ShoppingCartTest
{
    private const long ProductId = 10;
    private const int Quantity = 2;

    [Fact]
    public void Add_New_Check_ProductQuantity_Success()
    {
        var shoppingCart = new ShoppingCart(0);
        shoppingCart.Add(ProductId, Quantity);
        var productQuantity = shoppingCart.GetProductQuantity(ProductId);
        Assert.Equal(productQuantity, Quantity);
    }

    [Fact]
    public void Add_Exists_Check_ProductQuantity_Success()
    {
        var shoppingCart = new ShoppingCart(0);
        shoppingCart.Add(ProductId, Quantity);
        var productQuantity = shoppingCart.GetProductQuantity(ProductId);
        Assert.Equal(Quantity, productQuantity);

        shoppingCart.Add(ProductId, 1);
        productQuantity = shoppingCart.GetProductQuantity(ProductId);
        Assert.Equal(Quantity + 1, productQuantity);
    }

    [Fact]
    public void Add_New_Then_Remove_Then_Check_ProductQuantity_Success()
    {
        var shoppingCart = new ShoppingCart(0);
        shoppingCart.Add(ProductId, Quantity);
        var productQuantity = shoppingCart.GetProductQuantity(ProductId);
        Assert.Equal(Quantity, productQuantity);

        shoppingCart.Remove(ProductId);
        productQuantity = shoppingCart.GetProductQuantity(ProductId);
        Assert.Null(productQuantity);
    }
}