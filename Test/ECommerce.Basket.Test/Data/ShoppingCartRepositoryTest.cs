using ECommerce.Basket.Data.Repositories;

namespace ECommerce.Basket.Test.Data;

public class ShoppingCartRepositoryTest : BaseEfRepoTestFixture
{
    private const long UserId = 10;
    private const long ProductId = 10;
    private const int Quantity = 2;

    [Fact]
    public async Task Given_InvalidUserId_When_FindByUserIdOrDefaultAsync_Then_ReturnsNullAsResult()
    {
        var shoppingCartRepository = new ShoppingCartRepository(_dbContext);
        var shoppingCart = await shoppingCartRepository.FindByUserIdOrDefaultAsync(0);
        Assert.Null(shoppingCart);
    }

    [Fact]
    public async Task Given_ValidData_When_PutAsync_Then_SuccessfullyInsertShoppingCart()
    {
        var shoppingCartRepository = new ShoppingCartRepository(_dbContext);
        var cart = new ShoppingCart(UserId);
        cart.Add(ProductId, Quantity);
        
        await shoppingCartRepository.PutAsync(cart);
        var shoppingCart = await shoppingCartRepository.FindByUserIdOrDefaultAsync(UserId);

        Assert.NotNull(shoppingCart);
        Assert.Equal(Quantity, shoppingCart.GetProductQuantity(ProductId));
    }

    [Fact]
    public async Task Given_ValidData_When_PutAsync_WithExistShoppingCart_Then_SuccessfullyUpdateShoppingCart()
    {
        var shoppingCartRepository = new ShoppingCartRepository(_dbContext);

        var cart = new ShoppingCart(UserId);
        cart.Add(ProductId, Quantity);
        await shoppingCartRepository.PutAsync(cart);
        cart.Add(ProductId, Quantity);
        await shoppingCartRepository.PutAsync(cart);

        var shoppingCart = await shoppingCartRepository.FindByUserIdOrDefaultAsync(UserId);
        Assert.NotNull(shoppingCart);
        Assert.Equal(Quantity * 2, shoppingCart.GetProductQuantity(ProductId));
    }

    [Fact]
    public async Task Given_ValidData_When_RemoveAsync_Then_SuccessfullyDeleteShoppingCart()
    {
        var shoppingCartRepository = new ShoppingCartRepository(_dbContext);

        await shoppingCartRepository.PutAsync(new ShoppingCart(UserId));
        var shoppingCart = await shoppingCartRepository.FindByUserIdOrDefaultAsync(UserId);
        Assert.NotNull(shoppingCart);

        await shoppingCartRepository.RemoveAsync(UserId);
        shoppingCart = await shoppingCartRepository.FindByUserIdOrDefaultAsync(UserId);
        Assert.Null(shoppingCart);
    }
}