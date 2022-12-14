using System.ComponentModel.DataAnnotations;

namespace SalesApi.Infrastructure.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
