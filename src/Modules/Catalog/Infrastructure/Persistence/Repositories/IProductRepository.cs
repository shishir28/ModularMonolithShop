using ModularMonolithShop.Catalog.Domain.Entities;
using ModularMonolithShop.Shared.Persistence.Repositories;

namespace ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;

public interface IProductRepository : IAsyncRepository<Product>
{
    Task<IList<Product>> GetAllProductsAsync();
    Task<IList<Product>> GetProductionsByCategoryAsync(string categoryName);
    Task<Product?> GetProductByIdAsync(Guid id);
}