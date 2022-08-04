using SalesApi.Infrastructure.DTOs;

namespace SalesApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(IEnumerable<OrderItemDto> orderItemDtos);
    }
}
