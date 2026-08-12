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
        ValidateQuantity(quantity);

        CartId = cartId;
        ProductVariantId = productVariantId;
        Quantity = quantity;
    }

    public void IncreaseQuantity(int quantity)
    {
        ValidatePositiveQuantity(quantity);

        Quantity += quantity;
    }

    public void DecreaseQuantity(int quantity)
    {
        ValidatePositiveQuantity(quantity);

        if (quantity >= Quantity)
        {
            throw new InvalidOperationException(
                "Cannot decrease cart item quantity below one.");
        }

        Quantity -= quantity;
    }

    public void UpdateQuantity(int quantity)
    {
        ValidateQuantity(quantity);

        Quantity = quantity;
    }

    private static void ValidateQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantity),
                "Cart item quantity must be greater than zero.");
        }
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