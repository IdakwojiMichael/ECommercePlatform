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
        ValidateUnitPrice(unitPrice);
        ValidateQuantity(quantity);

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
        ValidateQuantity(quantity);

        Quantity = quantity;
        TotalPrice = UnitPrice * quantity;
    }

    private static void ValidateUnitPrice(decimal unitPrice)
    {
        if (unitPrice <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(unitPrice),
                "Unit price must be greater than zero.");
        }
    }

    private static void ValidateQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantity),
                "Order item quantity must be greater than zero.");
        }
    }
}