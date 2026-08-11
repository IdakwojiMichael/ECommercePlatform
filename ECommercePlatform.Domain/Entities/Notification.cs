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
        CustomerId = customerId;
        Title = title;
        Message = message;
        IsRead = false;
    }

    public void MarkAsRead()
    {
        IsRead = true;
        ReadAt = DateTime.UtcNow;
    }

    public void MarkAsUnread()
    {
        IsRead = false;
        ReadAt = null;
    }
}