using ECommerce.Catalog.Application.Dtos;
using ECommerce.Catalog.Application.Queries;
using ECommerce.Catalog.Data.Persistence.DbContexts;
using ECommerce.Share.Abstractions.CQRS;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Catalog.Data.QueryHandlers;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductOverviewDto>
{
    private readonly CatalogContext _catalogContext;

    public GetProductQueryHandler(CatalogContext catalogContext)
    {
        _catalogContext = catalogContext;
    }

    public async Task<ProductOverviewDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var productEntity = await _catalogContext.Products.FirstOrDefaultAsync(i => i.Id == request.Id,
            cancellationToken: cancellationToken);

        Guard.IsNotNull(productEntity);

        var productOverviewDto = new ProductOverviewDto
        {
            Id = productEntity.Id,
            Name = productEntity.Name,
            Currency = productEntity.Price?.Currency,
            Price = productEntity.Price?.Amount,
            Description = productEntity.Description
        };

        return productOverviewDto;
    }
}