using ECommerce.Basket.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Basket.Data.Persistence.Configurations;

public class ShoppingCartItemEntityConfiguration : IEntityTypeConfiguration<ShoppingCartItemEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItemEntity> builder)
    {
        builder.ToTable("ShoppingCartItem");
        builder.HasKey(e => e.Id);
    }
}