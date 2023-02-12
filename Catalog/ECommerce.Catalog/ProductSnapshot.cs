namespace ECommerce.Catalog;

public record ProductSnapshot(long Id, string Name, string? Description, decimal Price, string Currency);