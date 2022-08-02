using SalesApi.DTOs;

namespace SalesApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(IEnumerable<OrderItemDto> orderItemDtos);
    }
}
