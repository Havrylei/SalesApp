using Microsoft.AspNetCore.Mvc;
using SalesApi.DTOs;
using SalesApi.Services.Interfaces;

namespace SalesApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrder([FromBody] IEnumerable<OrderItemDto> dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
            }

            await _orderService.CreateOrder(dto);

            return Ok();
        }
    }
}
