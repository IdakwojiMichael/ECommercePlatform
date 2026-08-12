using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Notification : BaseEntity
{
    public Guid CustomerId { get; private set; }

    public string Title { get; private set; } = null!;

    public string Message { get; private set; } = null!;

    public bool IsRead { get; private set; }

    public DateTime? ReadAt { get; private set; }

    public Customer Customer { get; private set; } = null!;

    private Notification()
    {
    }

    public Notification(
        Guid customerId,
        string title,
        string message)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException(
                "Notification title is required.",
                nameof(title));
        }

        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException(
                "Notification message is required.",
                nameof(message));
        }

        CustomerId = customerId;
        Title = title;
        Message = message;
        IsRead = false;
        ReadAt = null;
    }

    public void MarkAsRead()
    {
        if (IsRead)
        {
            return;
        }

        IsRead = true;
        ReadAt = DateTime.UtcNow;
    }

    public void MarkAsUnread()
    {
        IsRead = false;
        ReadAt = null;
    }
}