namespace ECommerce.Basket.Application.Dtos;

public class ShoppingCartItemDto
{
    public long Id { get; set; }
    public int Quantity { get; set; }

    public ProductOverviewDto? ProductOverview { get; set; }
}