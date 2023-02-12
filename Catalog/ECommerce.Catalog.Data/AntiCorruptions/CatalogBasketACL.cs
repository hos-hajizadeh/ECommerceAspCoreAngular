using ECommerce.AntiCorruptionLayer.CatalogBasket;
using ECommerce.Catalog.Data.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Catalog.Data.AntiCorruptions;

public class CatalogBasketACL : ICatalogBasketACL
{
    private readonly CatalogContext _catalogContext;

    public CatalogBasketACL(CatalogContext catalogContext)
    {
        _catalogContext = catalogContext;
    }

    public async Task<ProductOverviewDto> GetProductOverviewAsync(long productId)
    {
        var productEntity = await _catalogContext.Products.FirstOrDefaultAsync(i => i.Id == productId);
        Guard.IsNotNull(productEntity);

        return new ProductOverviewDto
        {
            Id = productId,
            Name = productEntity.Name
        };
    }

    public async Task<IEnumerable<ProductOverviewDto>> GetProductOverviewsAsync(IEnumerable<long> productIds)
    {
        var productEntity = await _catalogContext.Products
            .Where(i => productIds.Contains(i.Id))
            .ToListAsync();

        var productOverviewDtos = productEntity.Select(i => new ProductOverviewDto
        {
            Id = i.Id,
            Name = i.Name
        }).ToList();

        return productOverviewDtos;
    }
}