using ECommerce.AntiCorruptionLayer.CatalogBasket;
using ECommerce.Basket.Application.Dtos;
using ECommerce.Basket.Application.Queries;
using ECommerce.Basket.Data.Entities;
using ECommerce.Basket.Data.Persistence.DbContexts;
using ECommerce.Share.Abstractions;
using ECommerce.Share.Abstractions.CQRS;
using Microsoft.EntityFrameworkCore;
using ProductOverviewDto = ECommerce.AntiCorruptionLayer.CatalogBasket.ProductOverviewDto;

namespace ECommerce.Basket.Data.QueryHandlers;

public class GetUserShoppingCartQueryHandler : IQueryHandler<GetUserShoppingCartQuery, UserShoppingCartDto>
{
    private readonly BasketContext _basketContext;
    private readonly ICatalogBasketACL _catalogBasketACL;
    private readonly IWorkContext _workContext;

    public GetUserShoppingCartQueryHandler(IWorkContext workContext, BasketContext basketContext,
        ICatalogBasketACL catalogBasketACL)
    {
        _workContext = workContext;
        _basketContext = basketContext;
        _catalogBasketACL = catalogBasketACL;
    }

    public async Task<UserShoppingCartDto> Handle(GetUserShoppingCartQuery request, CancellationToken cancellationToken)
    {
        var userId = _workContext.GetCurrentUserId();
        var card = await _basketContext.ShoppingCarts
            .Include(i => i.Items)
            .FirstOrDefaultAsync(i => i.UserId == userId, cancellationToken);

        if (card == null)
            return new UserShoppingCartDto();

        var productOverviews = await GetProductOverviewDtosAsync(card);
        var shoppingCartItemDtos = card.Items.Join(productOverviews, i => i.ProductId, i => i.Id,
            (entity, overviewDto) => new ShoppingCartItemDto
            {
                Id = entity.Id,
                Quantity = entity.Quantity,
                ProductOverview = new Application.Dtos.ProductOverviewDto
                {
                    Id = overviewDto.Id,
                    Name = overviewDto.Name
                }
            }).ToList();

        var userShoppingCartDto = new UserShoppingCartDto
        {
            UserId = userId,
            Items = shoppingCartItemDtos
        };

        return userShoppingCartDto;
    }

    private async Task<IEnumerable<ProductOverviewDto>> GetProductOverviewDtosAsync(ShoppingCartEntity card)
    {
        var productsIds = card.Items.Select(i => i.ProductId).Distinct().ToList();
        var productOverviews = await _catalogBasketACL.GetProductOverviewsAsync(productsIds);
        return productOverviews;
    }
}