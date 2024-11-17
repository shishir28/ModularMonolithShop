using ModularMonolithShop.Shared.Kernel.Application.CQRS;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;
using FluentValidation;
using ModularMonolithShop.Catalog.Domain.Entities;

namespace ModularMonolithShop.Catalog.Application.Commands.CreateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Product.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Product.ImageFile).NotEmpty().WithMessage("Image is required");
        RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

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
        var updatedValue = ProductMapper.MapToEntity(command.Product);
        updatedValue = UpdateProduct(updatedValue, product);
           
        await _productRepository.UpdateAsync(updatedValue);
        return new UpdateProductResult(true);
    }

    private Product UpdateProduct(Product updatedValue, Product oldValue)
    {
        updatedValue.Id = oldValue.Id;
        updatedValue.CreatedAt = oldValue.CreatedAt;
        updatedValue.CreatedBy = oldValue.CreatedBy;
        return updatedValue;
    }
}
