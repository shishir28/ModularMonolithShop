using ModularMonolithShop.Catalog.Application.Queries.GetProductByCategory;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;
using Moq;
using Shouldly;
using ModularMonolithShop.Catalog.Domain.Entities;
namespace ModularMonolithShop.UnitTests.Modules.Catalog.Application.Queries;

public class GetProductByCategoryHandlerTests
{

    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly GetProductByCategoryHandler _sut;

    public GetProductByCategoryHandlerTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _sut = new GetProductByCategoryHandler(_mockProductRepository.Object);

    }

    private void Setup()
    {
        var productList = new List<Product>
        {
            new() {
                Name = "Product 1",
                Description = "Description 1",
                Price = 100,
                ImageUrl = "https://www.google.com",
                Categories = ["Category 1"]
            }
        };
        _mockProductRepository.Setup(x => x.GetProductionsByCategoryAsync(It.IsAny<string>()))
        .ReturnsAsync(productList);
    }


    [Fact]
    public async Task Handle_GetProductByCategory_Success()
    {
        // Arrange
        Setup();
        // Act
        var result = await _sut.Handle(new GetProductByCategoryQuery("Category 1"), CancellationToken.None);
        // Assert
        result.Products.Count().ShouldBe(1);
        result.Products.First().Name.ShouldBe("Product 1");
    }
}