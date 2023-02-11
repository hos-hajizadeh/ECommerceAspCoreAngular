using ECommerce.Share.Abstractions;

namespace ECommerce.Basket.Data.Entities;

public class ShoppingCartItemEntity : IDbEntity
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}