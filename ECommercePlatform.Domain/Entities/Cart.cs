using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid CustomerId { get; private set; }

    public Customer Customer { get; private set; } = null!;

    public ICollection<CartItem> Items { get; private set; }
        = new List<CartItem>();

    private Cart()
    {
    }

    public Cart(Guid customerId)
    {
        CustomerId = customerId;
    }
}