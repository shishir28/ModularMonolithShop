namespace ModularMonolithShop.Catalog.Application.Dtos;

public record ProductDto(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
);