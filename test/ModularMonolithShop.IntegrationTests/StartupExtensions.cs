using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithShop.Catalog.Infrastructure.Persistence;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;

namespace ModularMonolithShop.IntegrationTests
{
    internal static class StartupExtensions
    {
        internal static void AddPersistenceServices(this IServiceCollection services)
        {

            //services.RemoveAll(typeof(IdentityDbContext<ApplicationUser>));

            //Each time, we will have unique DB name so that not shared across tests
            var databaseName = $"ModularMonolithShopDB-{Guid.NewGuid()}";

            services.AddDbContext<CatalogDbContext>(options =>
                     options.UseInMemoryDatabase(databaseName));

            //services.AddEntityFrameworkStores<CatalogDbContext>()
            //    .AddDefaultTokenProviders(); ;

            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
