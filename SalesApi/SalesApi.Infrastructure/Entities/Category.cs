using System.ComponentModel.DataAnnotations;

namespace SalesApi.Infrastructure.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
