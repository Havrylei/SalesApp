using System.ComponentModel.DataAnnotations;

namespace SalesApi.Infrastructure.DTOs
{
    public class OrderItemDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
