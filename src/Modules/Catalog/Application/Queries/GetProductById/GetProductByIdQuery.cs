using ModularMonolithShop.Catalog.Application.Dtos;
using MediatR;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;

namespace ModularMonolithShop.Catalog.Application.Queries.GetProductByCategory;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(ProductDto Product) ;

    