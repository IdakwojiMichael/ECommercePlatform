using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class WishlistItem : BaseEntity
{
    public Guid WishlistId { get; private set; }

    public Guid ProductId { get; private set; }

    public Wishlist Wishlist { get; private set; } = null!;

    public Product Product { get; private set; } = null!;

    private WishlistItem()
    {
    }

    public WishlistItem(
        Guid wishlistId,
        Guid productId)
    {
        WishlistId = wishlistId;
        ProductId = productId;
    }
}