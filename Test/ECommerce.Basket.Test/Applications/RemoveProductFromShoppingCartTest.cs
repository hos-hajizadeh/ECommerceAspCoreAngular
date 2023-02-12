using ECommerce.Basket.Application.Commands;

namespace ECommerce.Basket.Test.Applications;

public class RemoveProductFromShoppingCartTest : BaseHandlersTestFixture
{
    [Fact]
    public async void Given_ValidData_Then_SuccessfullyRemoveProductFromShoppingCart()
    {
        await _mediator.Send(new AddProductToShoppingCartCommand()
        {
            ProductId = ProductId,
            Quantity = Quantity
        });

        var shoppingCart = await _shoppingCartRepository.FindByUserIdOrDefaultAsync(UserId);
        Assert.NotNull(shoppingCart);
        Assert.Equal(Quantity, shoppingCart.GetProductQuantity(ProductId));

        await _mediator.Send(new RemoveProductFromShoppingCartCommand()
        {
            ProductId = ProductId,
        });

        shoppingCart = await _shoppingCartRepository.FindByUserIdOrDefaultAsync(UserId);
        Assert.NotNull(shoppingCart);
        Assert.Null(shoppingCart.GetProductQuantity(ProductId));
    }
}