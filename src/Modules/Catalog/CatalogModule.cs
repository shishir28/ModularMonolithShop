
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ModularMonolithShop.Catalog.Infrastructure.Persistence;
using ModularMonolithShop.Shared.Persistence;
using ModularMonolithShop.Shared.Persistence.Seed;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Seed;

namespace ModularMonolithShop.Catalog;
public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services,
            IConfiguration configuration)
    {
        // Add services to the container.
        services.AddScoped<IDataSeeder, CatalogDataSeeder>();

        // Application 


        // Infrastructure services
        services.AddDbContext<CatalogDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Database"));
        });

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        // Infrastructure services
        app.UseMigrationsAsync<CatalogDbContext>().GetAwaiter().GetResult();
        app.SeedDataAsync<CatalogDbContext>().GetAwaiter().GetResult();
        return app;
    }
}