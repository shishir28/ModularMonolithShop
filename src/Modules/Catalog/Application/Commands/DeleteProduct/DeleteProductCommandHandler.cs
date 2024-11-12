using ModularMonolithShop.Shared.Kernel.Application.CQRS;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;

namespace ModularMonolithShop.Catalog.Application.Commands.DeleteProduct;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    private readonly IProductRepository _productRepository;
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        // need to validate incoming command request. Let do it using validator and pipeline after this commit 
        var product = await _productRepository.GetProductByIdAsync(command.ProductId);

        if (product == null)
            throw new Exception("Product not found"); // return custom exception,  not the generic one.  Fix it later

        await _productRepository.DeleteAsync(product);
        return new DeleteProductResult(true);
    }
}