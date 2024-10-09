using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ModularMonolithShop.Basket;

public static class BasketModule
{
    public static IServiceCollection AddBasketModule(this IServiceCollection services,
            IConfiguration configuration)
    {
        return services;
    }

    public static IApplicationBuilder UseBasketModule(this IApplicationBuilder app)
    {
        return app;
    }
}