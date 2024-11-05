using ModularMonolithShop.Catalog.Infrastructure.Persistence;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;

namespace ModularMonolithShop.Catalog.Application.Queries.GetProductByCategory;

public class GetProductByCategoryHandler(CatalogDbContext dbContext) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await dbContext.Products
        .AsNoTracking()
        .Where(x => x.Categories.Contains(request.Category))
        .OrderBy(x => x.Name)
        .ToListAsync(cancellationToken);

        var result = new GetProductByCategoryResult(products.Select(x => ProductMapper.MapToDto(x)).ToList());
        return result;
    }
}