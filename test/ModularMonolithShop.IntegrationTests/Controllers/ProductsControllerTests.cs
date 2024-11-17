using System.Net;
using System.Net.Http.Json;
using ModularMonolithShop.Catalog.Application.Commands.CreateProduct;
using ModularMonolithShop.Catalog.Application.Dtos;
using ModularMonolithShop.Catalog.Application.Queries.GetProductById;
using ModularMonolithShop.Catalog.Application.Queries.GetProducts;
using ModularMonolithShop.IntegrationTests.TestHelpers;
using Shouldly;

namespace ModularMonolithShop.IntegrationTests.Controllers
{
    public class ProductsControllerTests(CustomWebApplicationFactory<Program> factory) : BaseControllerTests(factory)
    {
        [Fact]
        public async Task GetAll_Products_Returns_Expected_Products()
        {
            var client = await base.CreateAnonymousWebClientAsync();
            var response = await client.GetJsonAsync<GetProductsResult>("/api/v1/products");
            response.Products!.Count().ShouldBe(3);
        }

        [Fact]
        public async Task GetAll_Products_For_Categories_Returns_Expected_Products()
        {
            var client = await base.CreateAnonymousWebClientAsync();
            var response = await client.GetJsonAsync<GetProductsResult>("/api/v1/products/category/category1");
            response.Products!.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Get_Product_For_Id_Returns_Expected_Product()
        {
            var Id = new Guid("b706a19f-57b4-4142-a7e9-1283495d43b2");//Huawei Plus
            var client = await base.CreateAnonymousWebClientAsync();
            var expectedProduct = GenesisDataState.GetProducts().FirstOrDefault(x => x.Name == "Huawei Plus");
            var currentProduct = await client.GetJsonAsync<GetProductByIdResult>($"/api/v1/products/{Id}");

            currentProduct.Product.Id.ShouldBe(Id);
            currentProduct.Product.Name.ShouldBe("Huawei Plus");
            currentProduct.Product.Description.ShouldBe("Long description");
            currentProduct.Product.Price.ShouldBe(650);
        }

        [Fact]
        public async Task Post_With_Valid_Product_Returns_CreatedResult()
        {
            var client = await base.CreateAnonymousWebClientAsync();
            var product = new ProductDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Description = "Test Description",
                ImageFile = "RandomFileName",
                Price = 100,
                Categories = ["Category3"]
            };
            var createProductCommand = new CreateProductCommand(product);
            var response = await client.PostJsonAsync("/api/v1/products", createProductCommand!);
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
        }


        [Fact]
        public async Task Put_With_Valid_Product_Updates_Database()
        {
            var newDescription = "Latest Model for Huawei Plus";
            var newPrice = 1500;

            var client = await base.CreateAnonymousWebClientAsync();
            var expectedProduct = GenesisDataState.GetProducts().First(x => x.Name == "Huawei Plus");
            var product = new ProductDto
            {
                Id = expectedProduct.Id,
                Name = expectedProduct.Name,
                Description = newDescription,
                ImageFile = expectedProduct.ImageUrl,
                Price = newPrice,
                Categories = expectedProduct.Categories
            };
            var updateProductCommand = new UpdateProductCommand(product);
            var response = await client.PutAsJsonAsync("/api/v1/products", updateProductCommand!);
            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
            //var UpdatedProduct = GenesisDataState.GetProducts().First(x => x.Name == "Huawei Plus");
            //UpdatedProduct.Price.ShouldBe(newPrice);
            //UpdatedProduct.Description.ShouldBe(newDescription);
        }


        [Fact]
        public async Task Delete_With_Valid_Product_Should_Delete_From_Database()
        {
            var client = await base.CreateAnonymousWebClientAsync();
            var expectedProduct = GenesisDataState.GetProducts().First(x => x.Name == "Huawei Plus");
            var response = await client.DeleteAsync($"/api/v1/products/{expectedProduct.Id}");
            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
            //var UpdatedProduct = GenesisDataState.GetProducts().First(x => x.Name == "Huawei Plus");
            //UpdatedProduct.Price.ShouldBe(newPrice);
            //UpdatedProduct.Description.ShouldBe(newDescription);
        }
    }
}
