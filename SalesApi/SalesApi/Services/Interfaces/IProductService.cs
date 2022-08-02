using SalesApi.DTOs;

namespace SalesApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync(Guid categoryId);
    }
}
