using ModularMonolithShop.Catalog.Application.Queries.GetProductByCategory;
using ModularMonolithShop.Catalog.Infrastructure.Persistence.Repositories;
using Moq;
using Shouldly;
using ModularMonolithShop.Catalog.Domain.Entities;
using ModularMonolithShop.Catalog.Application.Queries.GetProductById;
namespace ModularMonolithShop.UnitTests.Modules.Catalog.Application.Queries;

public class GetProductByIdHandlerTests
{

    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly GetProductByIdHandler _sut;

    public GetProductByIdHandlerTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _sut = new GetProductByIdHandler(_mockProductRepository.Object);
    }

    [Fact]
    public async Task Handle_GetProductByCategory_Success()
    {
        // Arrange 
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Product 1",
            Description = "Description 1",
            Price = 100,
            ImageUrl = "https://www.google.com",
            Categories = ["Category 1"]
        };
        _mockProductRepository.Setup(x => x.GetProductByIdAsync(It.IsAny<Guid>()))
        .ReturnsAsync(product);
        // Act
        var result = await _sut.Handle(new GetProductByIdQuery(product.Id), CancellationToken.None);
        // Assert
        result.Product.ShouldNotBeNull();
        result.Product.Id.ShouldBe(product.Id);
    }
}