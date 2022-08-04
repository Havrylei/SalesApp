using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesApi.Infrastructure.DTOs;
using SalesApi.Infrastructure;
using SalesApi.Services.Interfaces;

namespace SalesApi.Services
{
    public class ProductService : IProductService, IDisposable
    {
        private readonly IMapper _mapper;
        private readonly SalesDbContext _salesDbContext;

        public ProductService(IMapper mapper, SalesDbContext salesDbContext)
        {
            _mapper = mapper;
            _salesDbContext = salesDbContext;
        }

        public void Dispose()
        {
            _salesDbContext.Dispose();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync(Guid categoryId)
        {
            var products = await _salesDbContext.Products
                .Where(x => x.CategoryId == categoryId)
                .OrderBy(x => x.Name)
                .ToListAsync();
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);

            return result;
        }
    }
}
