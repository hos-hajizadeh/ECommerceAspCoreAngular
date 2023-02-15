using ECommerce.Basket.Data.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace ECommerce.Basket.Data.Persistence.DbContexts;

public class BasketContext : DbContext
{
    public BasketContext()
    {
    }

    public BasketContext(DbContextOptions<BasketContext> options) : base(options)
    {
    }

    public virtual DbSet<ShoppingCartItemEntity> ShoppingCartItems { get; set; }
    public virtual DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasketContext).Assembly);
    }
}