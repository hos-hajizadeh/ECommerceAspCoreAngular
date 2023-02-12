using ECommerce.Basket.Application.Dtos;
using ECommerce.Basket.Application.Queries;
using ECommerce.Basket.Data.Persistence.DbContexts;
using ECommerce.Share.Abstractions;
using ECommerce.Share.Abstractions.CQRS;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Basket.Data.QueryHandlers;

public class GetUserShoppingCartQueryHandler : IQueryHandler<GetUserShoppingCartQuery, UserShoppingCartDto>
{
    private readonly IWorkContext _workContext;
    private readonly BasketContext _basketContext;

    public GetUserShoppingCartQueryHandler(IWorkContext workContext, BasketContext basketContext)
    {
        _workContext = workContext;
        _basketContext = basketContext;
    }

    public async Task<UserShoppingCartDto> Handle(GetUserShoppingCartQuery request, CancellationToken cancellationToken)
    {
        var userId = _workContext.GetCurrentUserId();
        var card = await _basketContext.ShoppingCarts
            .Include(i => i.Items)
            .FirstOrDefaultAsync(i => i.UserId == userId, cancellationToken: cancellationToken);

        if (card == null)
            return new UserShoppingCartDto();

        var shoppingCartItemDtos = card.Items.Select(entity => new ShoppingCartItemDto
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            ProductOverview = null //todo:
        }).ToList();

        var userShoppingCartDto = new UserShoppingCartDto
        {
            UserId = userId,
            Items = shoppingCartItemDtos
        };

        return userShoppingCartDto;
    }
}