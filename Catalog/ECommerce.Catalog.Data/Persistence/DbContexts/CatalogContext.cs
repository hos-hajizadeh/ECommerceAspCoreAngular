using ECommerce.Catalog.Data.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace ECommerce.Catalog.Data.Persistence.DbContexts;

public class CatalogContext : DbContext
{
    public CatalogContext()
    {
    }

    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }

    public virtual DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }
}