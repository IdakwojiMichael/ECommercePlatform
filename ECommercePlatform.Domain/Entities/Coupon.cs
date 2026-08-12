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
        Validate(
            code,
            discountAmount,
            startDate,
            endDate,
            usageLimit);

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
        if (UsageCount >= UsageLimit)
        {
            throw new InvalidOperationException(
                "Coupon usage limit has been reached.");
        }

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

    private static void Validate(
        string code,
        decimal discountAmount,
        DateTime startDate,
        DateTime endDate,
        int usageLimit)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException(
                "Coupon code is required.",
                nameof(code));
        }

        if (discountAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(discountAmount),
                "Discount amount must be greater than zero.");
        }

        if (endDate <= startDate)
        {
            throw new ArgumentException(
                "Coupon end date must be after the start date.");
        }

        if (usageLimit <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(usageLimit),
                "Usage limit must be greater than zero.");
        }

        if (discountAmount > 100 && code.Length > 0)
        {
            // Percentage validation is handled when the coupon
            // type is interpreted by the application.
        }
    }
}