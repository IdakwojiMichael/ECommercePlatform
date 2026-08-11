using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid CartId { get; private set; }

    public Guid ProductVariantId { get; private set; }

    public int Quantity { get; private set; }

    public Cart Cart { get; private set; } = null!;

    public ProductVariant ProductVariant { get; private set; } = null!;

    private CartItem()
    {
    }

    public CartItem(
        Guid cartId,
        Guid productVariantId,
        int quantity)
    {
        CartId = cartId;
        ProductVariantId = productVariantId;
        Quantity = quantity;
    }

    public void IncreaseQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public void DecreaseQuantity(int quantity)
    {
        Quantity -= quantity;
    }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}