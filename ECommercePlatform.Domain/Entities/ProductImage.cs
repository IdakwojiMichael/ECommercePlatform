using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class ProductImage : BaseEntity
{
    public Guid ProductId { get; private set; }

    public string ImageUrl { get; private set; } = null!;

    public string? AltText { get; private set; }

    public bool IsPrimary { get; private set; }

    public int DisplayOrder { get; private set; }

    public Product Product { get; private set; } = null!;

    private ProductImage()
    {
    }

    public ProductImage(
        Guid productId,
        string imageUrl,
        string? altText = null,
        bool isPrimary = false,
        int displayOrder = 0)
    {
        ProductId = productId;
        ImageUrl = imageUrl;
        AltText = altText;
        IsPrimary = isPrimary;
        DisplayOrder = displayOrder;
    }

    public void Update(
        string imageUrl,
        string? altText,
        bool isPrimary,
        int displayOrder)
    {
        ImageUrl = imageUrl;
        AltText = altText;
        IsPrimary = isPrimary;
        DisplayOrder = displayOrder;
    }

    public void SetAsPrimary()
    {
        IsPrimary = true;
    }

    public void RemoveAsPrimary()
    {
        IsPrimary = false;
    }
}