using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesApi.DTOs;
using SalesApi.Entities;
using SalesApi.Infrastructure;
using SalesApi.Services.Interfaces;

namespace SalesApi.Services
{
    public class OrderService : IOrderService, IDisposable
    {
        private readonly IMapper _mapper;
        private readonly SalesDbContext _salesDbContext;

        public OrderService(IMapper mapper, SalesDbContext salesDbContext)
        {
            _mapper = mapper;
            _salesDbContext = salesDbContext;
        }

        public async Task CreateOrder(IEnumerable<OrderItemDto> orderItemDtos)
        {
            var productIds = orderItemDtos.Select(x => x.ProductId);
            var products = await _salesDbContext.Products
                .Where(x => productIds.Contains(x.Id))
                .ToListAsync();

            if (productIds.Count() != products.Count)
            {
                throw new ArgumentException("Invalid products");
            }

            products.ForEach(x =>
            {
                x.StockQty -= orderItemDtos.First(y => y.ProductId == x.Id).Qty;

                if (x.StockQty < 0)
                {
                    throw new ArgumentException("Insufficient product quantity");
                }
            });

            var orderItems = _mapper.Map<IEnumerable<OrderItem>>(orderItemDtos);
            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                OrderItems = orderItems.ToList()
            };

            _salesDbContext.Orders.Add(order);

            await _salesDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _salesDbContext.Dispose();
        }
    }
}
