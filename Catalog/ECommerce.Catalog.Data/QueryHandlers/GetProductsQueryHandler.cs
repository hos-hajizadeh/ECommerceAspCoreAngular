using ECommerce.Catalog.Application.Dtos;
using ECommerce.Catalog.Application.Queries;
using ECommerce.Catalog.Data.Persistence.DbContexts;
using ECommerce.Share.Abstractions.CQRS;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Catalog.Data.QueryHandlers;

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<ProductOverviewDto>>
{
    private readonly CatalogContext _catalogContext;

    public GetProductsQueryHandler(CatalogContext catalogContext)
    {
        _catalogContext = catalogContext;
    }

    public async Task<List<ProductOverviewDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var productEntities = await _catalogContext.Products.ToListAsync(cancellationToken);
        var productOverviewDtos = productEntities.Select(i => new ProductOverviewDto
        {
            Id = i.Id,
            Name = i.Name,
            Currency = i.Price?.Currency,
            Price = i.Price?.Amount,
            Description = i.Description
        }).ToList();

        return productOverviewDtos;
    }
}