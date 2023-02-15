using ECommerce.Basket.Application.Commands;
using ECommerce.Basket.Application.Queries;

namespace ECommerce.Basket.Test.Applications;

public class GetUserShoppingCartTest : BaseHandlersTestFixture
{
    [Fact]
    public async void Given_ValidData_Then_SuccessfullyInsertShoppingCart_Then_GetUserShoppingCart()
    {
        await _mediator.Send(new AddProductToShoppingCartCommand
        {
            ProductId = ProductId,
            Quantity = Quantity
        });

        var shoppingCart = await _shoppingCartRepository.FindByUserIdOrDefaultAsync(UserId);
        Assert.NotNull(shoppingCart);
        Assert.Equal(Quantity, shoppingCart.GetProductQuantity(ProductId));

        var userShoppingCartDto = await _mediator.Send(new GetUserShoppingCartQuery());
        Assert.Equal(Quantity, userShoppingCartDto?.Items?.FirstOrDefault()?.Quantity ?? 0);
    }
}