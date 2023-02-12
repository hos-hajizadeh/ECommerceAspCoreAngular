namespace ECommerce.Basket.Api.Models;

public class AddProductToShoppingCartRequest
{
    public required long ProductId { get; set; }
    public int Quantity { get; set; }
}