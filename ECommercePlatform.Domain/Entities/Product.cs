using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Product : BaseEntity
{
    public Guid CategoryId { get; private set; }

    public Guid BrandId { get; private set; }

    public string Name { get; private set; } = null!;

    public string Slug { get; private set; } = null!;

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public Category Category { get; private set; } = null!;

    public Brand Brand { get; private set; } = null!;

    public ICollection<ProductImage> Images { get; private set; }
        = new List<ProductImage>();

    public ICollection<ProductVariant> Variants { get; private set; }
        = new List<ProductVariant>();

    public ICollection<Review> Reviews { get; private set; }
        = new List<Review>();

    private Product()
    {
    }

    public Product(
        Guid categoryId,
        Guid brandId,
        string name,
        string slug,
        string? description = null)
    {
        CategoryId = categoryId;
        BrandId = brandId;
        Name = name;
        Slug = slug;
        Description = description;
        IsActive = true;
    }

    public void Update(
        Guid categoryId,
        Guid brandId,
        string name,
        string slug,
        string? description)
    {
        CategoryId = categoryId;
        BrandId = brandId;
        Name = name;
        Slug = slug;
        Description = description;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}