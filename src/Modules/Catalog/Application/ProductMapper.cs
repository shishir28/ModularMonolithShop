using ModularMonolithShop.Catalog.Domain.Entities;
using Riok.Mapperly.Abstractions;
using ModularMonolithShop.Catalog.Application.Dtos;
namespace ModularMonolithShop.Catalog.Application;

[Mapper]
public static partial class ProductMapper
{
    private static string MapImageFile(Product product) =>
        $"{product.ImageUrl}";
    public static partial ProductDto MapToDto(Product product);
}