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
        ProductVariantId = productVariantId;
        QuantityAvailable = quantityAvailable;
        QuantityReserved = 0;
        ReorderLevel = reorderLevel;
        LastStockUpdate = DateTime.UtcNow;
    }

    public void AddStock(int quantity)
    {
        QuantityAvailable += quantity;
        LastStockUpdate = DateTime.UtcNow;
    }

    public void RemoveStock(int quantity)
    {
        QuantityAvailable -= quantity;
        LastStockUpdate = DateTime.UtcNow;
    }

    public void ReserveStock(int quantity)
    {
        QuantityAvailable -= quantity;
        QuantityReserved += quantity;
        LastStockUpdate = DateTime.UtcNow;
    }

    public void ReleaseStock(int quantity)
    {
        QuantityReserved -= quantity;
        QuantityAvailable += quantity;
        LastStockUpdate = DateTime.UtcNow;
    }
}