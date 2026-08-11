using ECommercePlatform.Domain.Common;
using ECommercePlatform.Domain.Enums;

namespace ECommercePlatform.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid OrderId { get; private set; }

    public string TransactionReference { get; private set; } = null!;

    public decimal Amount { get; private set; }

    public PaymentMethod Method { get; private set; }

    public PaymentStatus Status { get; private set; }

    public DateTime PaymentDate { get; private set; }

    public Order Order { get; private set; } = null!;

    private Payment()
    {
    }

    public Payment(
        Guid orderId,
        string transactionReference,
        decimal amount,
        PaymentMethod method)
    {
        OrderId = orderId;
        TransactionReference = transactionReference;
        Amount = amount;
        Method = method;
        Status = PaymentStatus.Pending;
    }

    public void MarkAsSuccessful()
    {
        Status = PaymentStatus.Successful;
        PaymentDate = DateTime.UtcNow;
    }

    public void MarkAsFailed()
    {
        Status = PaymentStatus.Failed;
        PaymentDate = DateTime.UtcNow;
    }

    public void UpdateStatus(PaymentStatus status)
    {
        Status = status;

        if (status == PaymentStatus.Successful ||
            status == PaymentStatus.Failed)
        {
            PaymentDate = DateTime.UtcNow;
        }
    }
}