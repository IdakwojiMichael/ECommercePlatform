using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Review : BaseEntity
{
    public Guid ProductId { get; private set; }

    public Guid CustomerId { get; private set; }

    public int Rating { get; private set; }

    public string Comment { get; private set; } = null!;

    public bool IsApproved { get; private set; }

    public Product Product { get; private set; } = null!;

    public Customer Customer { get; private set; } = null!;

    private Review()
    {
    }

    public Review(
        Guid productId,
        Guid customerId,
        int rating,
        string comment)
    {
        ValidateRating(rating);

        ProductId = productId;
        CustomerId = customerId;
        Rating = rating;
        Comment = comment;
        IsApproved = false;
    }

    public void Update(
        int rating,
        string comment)
    {
        ValidateRating(rating);

        Rating = rating;
        Comment = comment;
    }

    public void Approve()
    {
        IsApproved = true;
    }

    public void Reject()
    {
        IsApproved = false;
    }

    private static void ValidateRating(int rating)
    {
        if (rating < 1 || rating > 5)
        {
            throw new ArgumentOutOfRangeException(
                nameof(rating),
                "Rating must be between 1 and 5.");
        }
    }
}