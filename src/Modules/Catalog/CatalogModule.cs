using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ModularMonolithShop.Catalog;
public static class CatalogModule
{

    public static IServiceCollection AddCatalogModule(this IServiceCollection services,
            IConfiguration configuration)
    {
        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        return app;
    }
}