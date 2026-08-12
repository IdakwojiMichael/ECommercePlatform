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

    public DateTime? PaymentDate { get; private set; }

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
        if (string.IsNullOrWhiteSpace(transactionReference))
        {
            throw new ArgumentException(
                "Transaction reference is required.",
                nameof(transactionReference));
        }

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount),
                "Payment amount must be greater than zero.");
        }

        OrderId = orderId;
        TransactionReference = transactionReference;
        Amount = amount;
        Method = method;
        Status = PaymentStatus.Pending;
        PaymentDate = null;
    }

    public void MarkAsSuccessful()
    {
        if (Status == PaymentStatus.Successful)
        {
            return;
        }

        if (Status == PaymentStatus.Failed)
        {
            throw new InvalidOperationException(
                "A failed payment cannot be marked as successful.");
        }

        Status = PaymentStatus.Successful;
        PaymentDate = DateTime.UtcNow;
    }

    public void MarkAsFailed()
    {
        if (Status == PaymentStatus.Successful)
        {
            throw new InvalidOperationException(
                "A successful payment cannot be marked as failed.");
        }

        Status = PaymentStatus.Failed;
        PaymentDate = DateTime.UtcNow;
    }
}