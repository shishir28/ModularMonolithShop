using ModularMonolithShop.Catalog.Application.Queries.GetProductByCategory;
using ModularMonolithShop.Catalog.Infrastructure.Persistence;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;

namespace ModularMonolithShop.Catalog.Application.Queries.GetProductById;

public class GetProductByIdHandler(CatalogDbContext dbContext) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products
        .AsNoTracking()
        .Where(x => x.Id == request.Id)
        .SingleOrDefaultAsync(cancellationToken);

        var result = new GetProductByIdResult(ProductMapper.MapToDto(product!));

        return result;
    }
}

