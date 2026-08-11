using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class ProductVariant : BaseEntity
{
    public Guid ProductId { get; private set; }

    public string SKU { get; private set; } = null!;

    public string? Color { get; private set; }

    public string? Size { get; private set; }

    public decimal Price { get; private set; }

    public bool IsActive { get; private set; }

    public Product Product { get; private set; } = null!;

    public Inventory? Inventory { get; private set; }

    private ProductVariant()
    {
    }

    public ProductVariant(
        Guid productId,
        string sku,
        decimal price,
        string? color = null,
        string? size = null)
    {
        ProductId = productId;
        SKU = sku;
        Price = price;
        Color = color;
        Size = size;
        IsActive = true;
    }

    public void Update(
        string sku,
        decimal price,
        string? color,
        string? size)
    {
        SKU = sku;
        Price = price;
        Color = color;
        Size = size;
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