using ECommerce.Share.Abstractions;

namespace ECommerce.Catalog;

public class Product : ISnapshot<ProductSnapshot>
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required Money Price { get; set; }
    public string? Description { get; set; }

    public ProductSnapshot TakeSnapshot()
    {
        return new ProductSnapshot(Id, Name, Description, Price, Price.Currency.Name);
    }
}