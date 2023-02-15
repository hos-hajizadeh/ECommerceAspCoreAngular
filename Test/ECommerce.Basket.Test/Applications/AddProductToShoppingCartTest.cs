using ECommerce.Basket.Application.Commands;

namespace ECommerce.Basket.Test.Applications;

public class AddProductToShoppingCartTest : BaseHandlersTestFixture
{
    [Fact]
    public async void Given_ValidData_Then_SuccessfullyInsertShoppingCart()
    {
        await _mediator.Send(new AddProductToShoppingCartCommand
        {
            ProductId = ProductId,
            Quantity = Quantity
        });

        var shoppingCart = await _shoppingCartRepository.FindByUserIdOrDefaultAsync(UserId);
        Assert.NotNull(shoppingCart);
        Assert.Equal(Quantity, shoppingCart.GetProductQuantity(ProductId));
    }

    [Fact]
    public async void Given_ValidData_When_WithExistShoppingCart_Then_SuccessfullyUpdateShoppingCart()
    {
        await _mediator.Send(new AddProductToShoppingCartCommand
        {
            ProductId = ProductId,
            Quantity = Quantity
        });

        await _mediator.Send(new AddProductToShoppingCartCommand
        {
            ProductId = ProductId,
            Quantity = Quantity
        });

        var shoppingCart = await _shoppingCartRepository.FindByUserIdOrDefaultAsync(UserId);
        Assert.NotNull(shoppingCart);
        Assert.Equal(Quantity * 2, shoppingCart.GetProductQuantity(ProductId));
    }
}