using ModularMonolithShop.Catalog.Application.Dtos;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;

namespace ModularMonolithShop.Catalog.Application.Queries.GetProducts;

public record GetProductsQuery() : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<ProductDto> Products) ;

