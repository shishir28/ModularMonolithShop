using ModularMonolithShop.Shared.Persistence.Seed;

namespace ModularMonolithShop.Catalog.Infrastructure.Persistence.Seed;

public class CatalogDataSeeder : IDataSeeder
{
    private readonly CatalogDbContext _dbContext;
    public CatalogDataSeeder(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedAllAsync(CancellationToken cancellationToken = default)
    {

        // TODO: Seed data
        if (!await _dbContext.Products.AnyAsync())
        {
            var products = InitialData.Products;
            _dbContext.Products.AddRange(products);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        await Task.CompletedTask;
    }
}