using ECommerce.Basket.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Basket.Data.Persistence.Configurations;

public class ShoppingCartEntityConfiguration : IEntityTypeConfiguration<ShoppingCartEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingCartEntity> builder)
    {
        builder.ToTable("ShoppingCart");
        builder.HasKey(e => e.Id);
        //  builder.Property(e => e.UserId).ValueGeneratedNever();

        builder.HasMany<ShoppingCartItemEntity>(i => i.Items);
    }
}