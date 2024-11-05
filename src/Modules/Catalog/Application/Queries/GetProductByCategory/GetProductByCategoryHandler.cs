using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;

namespace ModularMonolithShop.Catalog.Application.Queries.GetProductByCategory;

public class GetProductByCategoryHandler(IProductRepository productRepository) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductionsByCategoryAsync(request.Category);
        var result = new GetProductByCategoryResult(products.Select(x => ProductMapper.MapToDto(x)).ToList());
        return result;
    }
}