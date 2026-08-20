using ECommercePlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommercePlatform.Persistence.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.QuantityAvailable)
            .IsRequired();

        builder.Property(x => x.QuantityReserved)
            .IsRequired();

        builder.Property(x => x.ReorderLevel)
            .IsRequired();

        builder.Property(x => x.LastStockUpdate)
            .IsRequired();

        builder.HasIndex(x => x.ProductVariantId)
            .IsUnique();

        builder.HasOne(x => x.ProductVariant)
            .WithOne(x => x.Inventory)
            .HasForeignKey<Inventory>(x => x.ProductVariantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}