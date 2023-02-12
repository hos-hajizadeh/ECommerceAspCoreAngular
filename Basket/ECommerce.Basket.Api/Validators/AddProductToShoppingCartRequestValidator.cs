using ECommerce.Basket.Api.Models;
using FluentValidation;

namespace ECommerce.Basket.Api.Validators;

public class AddProductToShoppingCartRequestValidator : AbstractValidator<AddProductToShoppingCartRequest>
{
    public AddProductToShoppingCartRequestValidator()
    {
        RuleFor(x => x.ProductId).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}