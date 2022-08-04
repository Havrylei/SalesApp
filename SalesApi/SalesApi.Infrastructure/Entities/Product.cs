using System.ComponentModel.DataAnnotations;

namespace SalesApi.Infrastructure.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQty { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public Category Category { get; set; }
    }
}
