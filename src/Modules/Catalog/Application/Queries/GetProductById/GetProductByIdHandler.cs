using ModularMonolithShop.Catalog.Application.Queries.GetProductByCategory;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;

namespace ModularMonolithShop.Catalog.Application.Queries.GetProductById;
public class GetProductByIdHandler(IProductRepository productRepository) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductByIdAsync(request.Id);
        var result = new GetProductByIdResult(ProductMapper.MapToDto(product!));
        return result;
    }
}

