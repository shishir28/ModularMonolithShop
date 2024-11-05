using ModularMonolithShop.Catalog.Domain.Entities;

namespace ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;

public interface IProductRepository
{
    Task<IList<Product>> GetProductionsByCategoryAsync(string categoryName);
}