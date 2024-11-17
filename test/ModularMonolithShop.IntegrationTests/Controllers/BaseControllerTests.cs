using Microsoft.Extensions.DependencyInjection;
using ModularMonolithShop.Catalog.Infrastructure.Persistence;

namespace ModularMonolithShop.IntegrationTests.Controllers
{
    public class BaseControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        protected readonly CustomWebApplicationFactory<Program> _factory;

        internal BaseControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("http://localhost");
            _factory = factory;
            SetupInitialData();
        }

        protected void SetupInitialData()
        {
            var serviceProvider = _factory.Services.GetService<IServiceProvider>();
            using var scope = serviceProvider!.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
            GenesisDataState.ResetCatalogDatabaseState(dbContext).Wait();
        }

        protected HttpClient CreateHttpClient() => _factory.CreateClient();

        protected async Task<HttpClient> CreateAnonymousWebClientAsync()
        {
            //var accessToken = await LoginDefaultUserAsync();
            var client = CreateHttpClient();
            return await Task.FromResult(client);
        }
    }
}
