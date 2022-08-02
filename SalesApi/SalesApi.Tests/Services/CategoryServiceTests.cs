using AutoFixture;
using FluentAssertions;
using SalesApi.Entities;
using SalesApi.Services;

namespace SalesApi.Tests.Services
{
    public class CategoryServiceTests : BaseServiceTest
    {
        private readonly CategoryService _categoryService;

        public CategoryServiceTests()
        {
            _categoryService = new CategoryService(_mapper, _dbContext);
        }

        [Fact]
        public async Task GetCategoriesAsync_ReturnsResult()
        {
            var categories = _fixture.CreateMany<Category>();

            await _dbContext.AddRangeAsync(categories);
            await _dbContext.SaveChangesAsync();

            var result = await _categoryService.GetCategoriesAsync();

            result.Should().NotBeEmpty();

            var expectedCategory = categories.First();
            var resultCategory = result.FirstOrDefault(x => x.Id == expectedCategory.Id);

            resultCategory.Should().NotBeNull();
            resultCategory.Name.Should().Be(expectedCategory.Name);
        }

        [Fact]
        public async Task GetCategoriesAsync_EmptyCategoryTable_ReturnsEmptyResult()
        {
            var result = await _categoryService.GetCategoriesAsync();

            result.Should().BeEmpty();
        }
    }
}
