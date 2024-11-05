using ModularMonolithShop.Catalog.Domain.Events;
using ModularMonolithShop.Shared.Kernel;

namespace ModularMonolithShop.Catalog.Domain.Entities;

public class Product : Aggregate<Guid>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;
    public List<string> Categories { get; set; } = [];

    public static Product Create(Guid id, string name, List<string> categories, string description, string imageUrl,
        decimal price)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            ImageUrl = imageUrl,
            Categories = categories
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));
        return product;
    }

    public void Update(string name, List<string> categories, string description, string imageUrl, decimal price)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        Name = name;
        Description = description;

        ImageUrl = imageUrl;
        Categories = categories;

        if (price == Price) return;
        Price = price;
        AddDomainEvent(new ProductPriceChangeEvent(this));
    }
}