using ModularMonolithShop.Catalog.Domain.Entities;
using ModularMonolithShop.Shared.Persistence.Repositories;

namespace ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(CatalogDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<IList<Product>> GetAllProductsAsync()
    {

        var products = await GetCatalogDbContext().Products
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
        return products;
    }

    public async Task<IList<Product>> GetProductionsByCategoryAsync(string categoryName)
    {
        var products = await GetCatalogDbContext().Products
            .AsNoTracking()
            .Where(x => x.Categories.Contains(categoryName))
            .OrderBy(x => x.Name)
            .ToListAsync();
        return products;
    }

    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        var product = await GetCatalogDbContext().Products
            .AsNoTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        return product;
    }

    private CatalogDbContext GetCatalogDbContext() => _dbContext as CatalogDbContext;


}