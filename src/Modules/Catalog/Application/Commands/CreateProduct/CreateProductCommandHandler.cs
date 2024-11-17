using ModularMonolithShop.Shared.Kernel.Application.CQRS;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;
using FluentValidation;

namespace ModularMonolithShop.Catalog.Application.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Product.Categories).NotEmpty().WithMessage("Categories is required");
        RuleFor(x => x.Product.ImageFile).NotEmpty().WithMessage("Image is required");
        RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

public class CreateProductCommandHandler(IProductRepository productRepository) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // need to validate incoming command request. Let do it using validator and pipeline after this commit 
        var result = await _productRepository.AddAsync(ProductMapper.MapToEntity(command.Product));
        return new CreateProductResult(result.Id);
    }
}
