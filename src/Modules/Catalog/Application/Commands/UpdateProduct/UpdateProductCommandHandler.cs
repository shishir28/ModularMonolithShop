using ModularMonolithShop.Shared.Kernel.Application.CQRS;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;

namespace ModularMonolithShop.Catalog.Application.Commands.CreateProduct;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _productRepository;
    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        // need to validate incoming command request. Let do it using validator and pipeline after this commit 
        var product = await _productRepository.GetProductByIdAsync(command.Product.Id);

        if (product == null)
            throw new Exception("Product not found"); // return custom exception,  not the generic one.  Fix it later
        await _productRepository.UpdateAsync(ProductMapper.MapToEntity(command.Product));
        return new UpdateProductResult(true);
    }
}