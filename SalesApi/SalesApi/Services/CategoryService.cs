using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesApi.DTOs;
using SalesApi.Infrastructure;
using SalesApi.Services.Interfaces;

namespace SalesApi.Services
{
    public class CategoryService : ICategoryService, IDisposable
    {
        private readonly IMapper _mapper;
        private readonly SalesDbContext _salesDbContext;

        public CategoryService(IMapper mapper, SalesDbContext salesDbContext)
        {
            _mapper = mapper;
            _salesDbContext = salesDbContext;
        }

        public void Dispose()
        {
            _salesDbContext.Dispose();
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _salesDbContext.Categories.OrderBy(x => x.Name).ToListAsync();
            var result = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return result;
        }
    }
}
