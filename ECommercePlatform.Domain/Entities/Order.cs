using ECommercePlatform.Domain.Common;
using ECommercePlatform.Domain.Enums;

namespace ECommercePlatform.Domain.Entities;

public class Order : BaseEntity
{
    public Guid CustomerId { get; private set; }

    public Guid ShippingAddressId { get; private set; }

    public string OrderNumber { get; private set; } = null!;

    public decimal SubTotal { get; private set; }

    public decimal ShippingCost { get; private set; }

    public decimal DiscountAmount { get; private set; }

    public decimal TotalAmount { get; private set; }

    public OrderStatus Status { get; private set; }

    public DateTime OrderDate { get; private set; }

    public Customer Customer { get; private set; } = null!;

    public Address ShippingAddress { get; private set; } = null!;

    public ICollection<OrderItem> Items { get; private set; }
        = new List<OrderItem>();

    public ICollection<Payment> Payments { get; private set; }
        = new List<Payment>();

    private Order()
    {
    }

    public Order(
        Guid customerId,
        Guid shippingAddressId,
        string orderNumber,
        decimal subTotal,
        decimal shippingCost,
        decimal discountAmount)
    {
        CustomerId = customerId;
        ShippingAddressId = shippingAddressId;
        OrderNumber = orderNumber;
        SubTotal = subTotal;
        ShippingCost = shippingCost;
        DiscountAmount = discountAmount;
        TotalAmount = subTotal + shippingCost - discountAmount;
        Status = OrderStatus.Pending;
        OrderDate = DateTime.UtcNow;
    }

    public void UpdateStatus(OrderStatus status)
    {
        Status = status;
    }
}