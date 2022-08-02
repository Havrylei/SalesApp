using AutoFixture;
using FluentAssertions;
using SalesApi.Entities;
using SalesApi.Services;

namespace SalesApi.Tests.Services
{
    public class ProductServiceTests : BaseServiceTest
    {
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productService = new ProductService(_mapper, _dbContext);
        }

        [Fact]
        public async Task GetProductsByCategoryIdAsync_ReturnsProductsOnlyForSpecificCategory()
        {
            var categories = _fixture.CreateMany<Category>();
            var selectedCategoryId = categories.First().Id;

            await _dbContext.AddRangeAsync(categories);
            await _dbContext.SaveChangesAsync();

            var result = await _productService.GetProductsByCategoryIdAsync(selectedCategoryId);

            result.Should().NotBeEmpty();

            var expectedProduct = categories.First(x => x.Id == selectedCategoryId).Products.First();
            var resultProduct = result.FirstOrDefault(x => x.Id == expectedProduct.Id);

            resultProduct.Should().NotBeNull();
            resultProduct.Name.Should().Be(expectedProduct.Name);
            resultProduct.Price.Should().Be(expectedProduct.Price);
            resultProduct.StockQty.Should().Be(expectedProduct.StockQty);
            resultProduct.ImageUrl.Should().Be(expectedProduct.ImageUrl);
            resultProduct.UpdatedAt.Should().Be(expectedProduct.UpdatedAt);
            resultProduct.CreatedAt.Should().Be(expectedProduct.CreatedAt);
        }

        [Fact]
        public async Task GetProductsByCategoryIdAsync_InexistingCategory_ReturnsEmptyResult()
        {
            var categories = _fixture.CreateMany<Category>();
            var selectedCategoryId = _fixture.Create<Guid>();

            await _dbContext.AddRangeAsync(categories);
            await _dbContext.SaveChangesAsync();

            var result = await _productService.GetProductsByCategoryIdAsync(selectedCategoryId);

            result.Should().BeEmpty();
        }
    }
}
