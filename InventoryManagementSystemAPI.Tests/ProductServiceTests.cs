using InventoryManagementSystemAPI.Models;
using InventoryManagementSystemAPI.Repositories;
using Moq;
using Xunit;

namespace InventoryManagementSystemAPI.InventoryManagementSystemAPI.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _productService = new ProductService(_mockRepo.Object);
        }

        [Fact]
        public async Task AddProduct_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var product = new Product { Name = "Test Product", QuantityInStock = 10 };

            // Act
            await _productService.AddProductAsync(product);

            // Assert
            _mockRepo.Verify(repo => repo.AddAsync(product), Times.Once);
        }

        [Fact]
        public async Task GetProductById_ShouldReturnProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Test Product", QuantityInStock = 10 };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _productService.GetProductByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Product", result.Name);
        }
    }
}
