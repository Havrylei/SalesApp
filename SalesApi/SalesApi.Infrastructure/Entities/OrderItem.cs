using System.ComponentModel.DataAnnotations;

namespace SalesApi.Infrastructure.Entities
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        [Required]
        public int Qty { get; set; }
        public Order Order { get; set; }
    }
}
