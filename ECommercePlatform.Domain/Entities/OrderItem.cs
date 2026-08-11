using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; private set; }

    public Guid ProductVariantId { get; private set; }

    public string ProductName { get; private set; } = null!;

    public string SKU { get; private set; } = null!;

    public decimal UnitPrice { get; private set; }

    public int Quantity { get; private set; }

    public decimal TotalPrice { get; private set; }

    public Order Order { get; private set; } = null!;

    public ProductVariant ProductVariant { get; private set; } = null!;

    private OrderItem()
    {
    }

    public OrderItem(
        Guid orderId,
        Guid productVariantId,
        string productName,
        string sku,
        decimal unitPrice,
        int quantity)
    {
        OrderId = orderId;
        ProductVariantId = productVariantId;
        ProductName = productName;
        SKU = sku;
        UnitPrice = unitPrice;
        Quantity = quantity;
        TotalPrice = unitPrice * quantity;
    }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
        TotalPrice = UnitPrice * quantity;
    }
}