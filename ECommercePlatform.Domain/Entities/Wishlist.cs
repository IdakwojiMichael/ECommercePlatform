using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Wishlist : BaseEntity
{
    public Guid CustomerId { get; private set; }

    public Customer Customer { get; private set; } = null!;

    public ICollection<WishlistItem> Items { get; private set; }
        = new List<WishlistItem>();

    private Wishlist()
    {
    }

    public Wishlist(Guid customerId)
    {
        CustomerId = customerId;
    }
}