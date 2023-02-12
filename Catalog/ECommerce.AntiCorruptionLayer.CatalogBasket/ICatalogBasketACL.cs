namespace ECommerce.AntiCorruptionLayer.CatalogBasket;

public interface ICatalogBasketACL
{
    public Task<ProductOverviewDto> GetProductOverviewAsync(long productId);
    public Task<IEnumerable<ProductOverviewDto>> GetProductOverviewsAsync(IEnumerable<long> productIds);
}