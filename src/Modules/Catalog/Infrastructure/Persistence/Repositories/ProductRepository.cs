using ModularMonolithShop.Catalog.Domain.Entities;

namespace ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;

public class ProductRepository(CatalogDbContext dbContext) : IProductRepository
{
    public async Task<IList<Product>> GetProductionsByCategoryAsync(string categoryName)
    {
        var products = await dbContext.Products
            .AsNoTracking()
            .Where(x => x.Categories.Contains(categoryName))
            .OrderBy(x => x.Name)
            .ToListAsync();
        return products;
    }

    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        var product = await dbContext.Products
            .AsNoTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        return product;
    }
}