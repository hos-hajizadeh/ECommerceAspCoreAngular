using ECommerce.Share.Abstractions;

namespace ECommerce.Catalog.Data.Entities;

public class ProductEntity : IDbEntity
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public Money? Price { get; set; }
    public string? Description { get; set; }
}