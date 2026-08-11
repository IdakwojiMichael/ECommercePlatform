using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public string? LogoUrl { get; private set; }

    public string? Website { get; private set; }

    public bool IsActive { get; private set; }

    public ICollection<Product> Products { get; private set; }
        = new List<Product>();

    private Brand()
    {
    }

    public Brand(
        string name,
        string? description = null,
        string? logoUrl = null,
        string? website = null)
    {
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        Website = website;
        IsActive = true;
    }

    public void Update(
        string name,
        string? description,
        string? logoUrl,
        string? website)
    {
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        Website = website;
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