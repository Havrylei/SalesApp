using SalesApi.Infrastructure.DTOs;

namespace SalesApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}
