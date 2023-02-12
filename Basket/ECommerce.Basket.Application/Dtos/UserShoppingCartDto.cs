namespace ECommerce.Basket.Application.Dtos;

public class UserShoppingCartDto
{
    public long UserId { get; init; }
    public List<ShoppingCartItemDto> Items { get; set; } = new();
}