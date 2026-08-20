using ECommercePlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommercePlatform.Persistence.Configurations;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable("ProductVariants");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.SKU)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.SKU)
            .IsUnique();

        builder.Property(x => x.Color)
            .HasMaxLength(100);

        builder.Property(x => x.Size)
            .HasMaxLength(100);

        builder.Property(x => x.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Variants)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Inventory)
            .WithOne(x => x.ProductVariant)
            .HasForeignKey<Inventory>(x => x.ProductVariantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}