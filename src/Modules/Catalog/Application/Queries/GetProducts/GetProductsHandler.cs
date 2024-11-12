using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;

namespace ModularMonolithShop.Catalog.Application.Queries.GetProducts;

public class GetProductsHandler(IProductRepository productRepository) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllProductsAsync();
        var result = new GetProductsResult(products.Select(x => ProductMapper.MapToDto(x)).ToList());
        return result;
    }
}