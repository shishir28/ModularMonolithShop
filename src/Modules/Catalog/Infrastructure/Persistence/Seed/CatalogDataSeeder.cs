using ModularMonolithShop.Shared.Persistence.Seed;

namespace ModularMonolithShop.Catalog.Infrastructure.Persistence.Seed;

public class CatalogDataSeeder(CatalogDbContext dbContext) : IDataSeeder
{
    private readonly CatalogDbContext _dbContext = dbContext;

    public async Task SeedAllAsync(CancellationToken cancellationToken = default)
    {    
        if (!await _dbContext.Products.AnyAsync())
        {
            var products = InitialData.Products;
            _dbContext.Products.AddRange(products);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        await Task.CompletedTask;
    }
}