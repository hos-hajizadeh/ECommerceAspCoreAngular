using ECommerce.Share.Abstractions;

namespace ECommerce.Basket.Data.Entities;

public class ShoppingCartEntity : IDbEntity
{
    public long Id { get; set; }
    public long UserId { get; init; }
    public ICollection<ShoppingCartItemEntity> Items { get; set; } = new List<ShoppingCartItemEntity>();
}