using ModularMonolithShop.Catalog.Domain.Entities;
using ModularMonolithShop.Catalog.Infrastructure.Persistence;

namespace ModularMonolithShop.IntegrationTests
{
    internal static class GenesisDataState
    {
        internal static async Task ResetCatalogDatabaseState(CatalogDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            await context.Products.AddRangeAsync(GetProducts());
            await context.SaveChangesAsync();
        }

        internal static IEnumerable<Product> GetProducts() =>
        [
           new() { Id =  Guid.Parse("b706a19f-57b4-4142-a7e9-1283495d43b2"),
                    Name="Huawei Plus",
                    Description = "Long description",
                    Price = 650,
                    ImageUrl= "ImageUrl1" ,
                    Categories = ["category1"] },

           new() { Id =  Guid.Parse("f1f1b8fc-53e1-4e74-8cc2-702e26fb314c"),
                    Name= "IPhone X",
                    Description = "Long description",
                    Price = 900,
                    ImageUrl= "ImageUrl2" ,
                    Categories = ["category1"] },

           new() { Id =  Guid.Parse("f1f1b8fc-53e1-4e74-8cc2-702e26fb314d"),
                    Name= "Samsung 10",
                    Description = "Long description",
                    Price = 1000,
                    ImageUrl= "ImageUrl3" ,
                    Categories = ["category2"] }
        ];

    }
}
