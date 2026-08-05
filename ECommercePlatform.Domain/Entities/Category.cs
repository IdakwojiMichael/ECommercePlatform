using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public string Slug { get; private set; } = null!;

    public string? ImageUrl { get; private set; }

    public bool IsActive { get; private set; }

    public Guid? ParentCategoryId { get; private set; }

    public Category? ParentCategory { get; private set; }

    public ICollection<Category> SubCategories { get; private set; } = new List<Category>();

    private Category()
    {
    }

    public Category(
        string name,
        string slug,
        string? description = null,
        string? imageUrl = null,
        Guid? parentCategoryId = null)
    {
        Name = name;
        Slug = slug;
        Description = description;
        ImageUrl = imageUrl;
        ParentCategoryId = parentCategoryId;
        IsActive = true;
    }

    public void Update(
        string name,
        string slug,
        string? description,
        string? imageUrl)
    {
        Name = name;
        Slug = slug;
        Description = description;
        ImageUrl = imageUrl;
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