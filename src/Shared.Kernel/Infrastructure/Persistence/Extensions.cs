using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithShop.Shared.Persistence.Seed;

namespace ModularMonolithShop.Shared.Persistence;

public static class Extensions
{
    public static async Task UseMigrationsAsync<TContext>(this IApplicationBuilder app)
    where TContext : DbContext
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<TContext>();
        await context.Database.MigrateAsync();
    }

    public static async Task SeedDataAsync<TContext>(this IApplicationBuilder app)
    where TContext : DbContext
    {
        using var scope = app.ApplicationServices.CreateScope();
        var seeders = scope.ServiceProvider.GetServices<IDataSeeder>();
        foreach (var seeder in seeders)
        {
            await seeder.SeedAllAsync(CancellationToken.None);
        }
    }
}