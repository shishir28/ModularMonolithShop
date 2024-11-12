using ModularMonolithShop.Catalog.Application.Dtos;
using MediatR;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;

namespace ModularMonolithShop.Catalog.Application.Commands.CreateProduct;

public record UpdateProductCommand(ProductDto Product)
    : ICommand<UpdateProductResult>;
public record UpdateProductResult(bool IsSuccess);

