using ModularMonolithShop.Catalog.Application.Dtos;
using MediatR;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;

namespace ModularMonolithShop.Catalog.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _productRepository;
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // need to validate incoming command request. Let do it using validator and pipeline after this commit 
        var result = await _productRepository.AddAsync(ProductMapper.MapToEntity(command.Product));
        return new CreateProductResult(result.Id);
    }
}