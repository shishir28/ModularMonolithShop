using ModularMonolithShop.Catalog.Domain.Entities;
using Riok.Mapperly.Abstractions;
using ModularMonolithShop.Catalog.Application.Dtos;
namespace ModularMonolithShop.Catalog.Application;

[Mapper]
public static partial class ProductMapper
{
    [MapperIgnoreSource(nameof(Product.CreatedAt))]
    [MapperIgnoreSource(nameof(Product.CreatedBy))]
    [MapperIgnoreSource(nameof(Product.LastModifiedAt))]
    [MapperIgnoreSource(nameof(Product.LastModifiedBy))]
    [MapperIgnoreSource(nameof(Product.DomainEvents))]
    [MapProperty(nameof(Product.ImageUrl), nameof(ProductDto.ImageFile))]
    public static partial ProductDto MapToDto(Product product);

    [MapperIgnoreTarget(nameof(Product.CreatedAt))]
    [MapperIgnoreSource(nameof(Product.CreatedBy))]
    [MapperIgnoreTarget(nameof(Product.LastModifiedAt))]
    [MapperIgnoreTarget(nameof(Product.LastModifiedBy))]
    [MapperIgnoreTarget(nameof(Product.DomainEvents))]
    [MapProperty(nameof(ProductDto.ImageFile), nameof(Product.ImageUrl))]
    public static partial Product MapToEntity(ProductDto product);




}