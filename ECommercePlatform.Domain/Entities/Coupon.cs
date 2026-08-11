using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Coupon : BaseEntity
{
    public string Code { get; private set; } = null!;

    public string? Description { get; private set; }

    public decimal DiscountAmount { get; private set; }

    public bool IsPercentage { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public int UsageLimit { get; private set; }

    public int UsageCount { get; private set; }

    public bool IsActive { get; private set; }

    private Coupon()
    {
    }

    public Coupon(
        string code,
        decimal discountAmount,
        bool isPercentage,
        DateTime startDate,
        DateTime endDate,
        int usageLimit,
        string? description = null)
    {
        Code = code;
        DiscountAmount = discountAmount;
        IsPercentage = isPercentage;
        StartDate = startDate;
        EndDate = endDate;
        UsageLimit = usageLimit;
        UsageCount = 0;
        Description = description;
        IsActive = true;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void IncrementUsage()
    {
        UsageCount++;
    }

    public bool IsValid()
    {
        var now = DateTime.UtcNow;

        return IsActive
            && now >= StartDate
            && now <= EndDate
            && UsageCount < UsageLimit;
    }
}