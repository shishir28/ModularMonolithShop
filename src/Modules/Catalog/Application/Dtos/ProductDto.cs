namespace ModularMonolithShop.Catalog.Application.Dtos;

public record ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public decimal Price { get; init; }
    public string ImageFile { get; init; } = default!;
    public List<string> Categories { get; init; } = [];
}

