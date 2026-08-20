using ECommercePlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommercePlatform.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.OrderNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.OrderNumber)
            .IsUnique();

        builder.Property(x => x.SubTotal)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.ShippingCost)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.DiscountAmount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.TotalAmount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.OrderDate)
            .IsRequired();

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Payments)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(
            x => x.ShippingAddress,
            shippingAddress =>
            {
                shippingAddress.Property(x => x.AddressLine)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("ShippingAddressLine");

                shippingAddress.Property(x => x.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ShippingCity");

                shippingAddress.Property(x => x.State)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ShippingState");

                shippingAddress.Property(x => x.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ShippingCountry");

                shippingAddress.Property(x => x.PostalCode)
                    .HasMaxLength(20)
                    .HasColumnName("ShippingPostalCode");

                shippingAddress.Property(x => x.PhoneNumber)
                    .HasMaxLength(30)
                    .HasColumnName("ShippingPhoneNumber");
            });
    }
}