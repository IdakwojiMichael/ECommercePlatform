using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Inventory : BaseEntity
{
    public Guid ProductVariantId { get; private set; }

    public int QuantityAvailable { get; private set; }

    public int QuantityReserved { get; private set; }

    public int ReorderLevel { get; private set; }

    public DateTime LastStockUpdate { get; private set; }

    public ProductVariant ProductVariant { get; private set; } = null!;

    private Inventory()
    {
    }

    public Inventory(
        Guid productVariantId,
        int quantityAvailable,
        int reorderLevel = 10)
    {
        if (quantityAvailable < 0)
            throw new ArgumentOutOfRangeException(
                nameof(quantityAvailable),
                "Quantity available cannot be negative.");

        if (reorderLevel < 0)
            throw new ArgumentOutOfRangeException(
                nameof(reorderLevel),
                "Reorder level cannot be negative.");

        ProductVariantId = productVariantId;
        QuantityAvailable = quantityAvailable;
        QuantityReserved = 0;
        ReorderLevel = reorderLevel;
        LastStockUpdate = DateTime.UtcNow;
    }

    public void AddStock(int quantity)
    {
        ValidatePositiveQuantity(quantity);

        QuantityAvailable += quantity;
        LastStockUpdate = DateTime.UtcNow;
    }

    public void RemoveStock(int quantity)
    {
        ValidatePositiveQuantity(quantity);

        if (quantity > QuantityAvailable)
        {
            throw new InvalidOperationException(
                "Cannot remove more stock than is available.");
        }

        QuantityAvailable -= quantity;
        LastStockUpdate = DateTime.UtcNow;
    }

    public void ReserveStock(int quantity)
    {
        ValidatePositiveQuantity(quantity);

        if (quantity > QuantityAvailable)
        {
            throw new InvalidOperationException(
                "Cannot reserve more stock than is available.");
        }

        QuantityAvailable -= quantity;
        QuantityReserved += quantity;
        LastStockUpdate = DateTime.UtcNow;
    }

    public void ReleaseStock(int quantity)
    {
        ValidatePositiveQuantity(quantity);

        if (quantity > QuantityReserved)
        {
            throw new InvalidOperationException(
                "Cannot release more stock than is reserved.");
        }

        QuantityReserved -= quantity;
        QuantityAvailable += quantity;
        LastStockUpdate = DateTime.UtcNow;
    }

    private static void ValidatePositiveQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantity),
                "Quantity must be greater than zero.");
        }
    }
}