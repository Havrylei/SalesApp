using Microsoft.EntityFrameworkCore;
using SalesApi.Entities;

namespace SalesApi.Infrastructure.Extensions
{
    public static class SeedGenerator
    {
        public static void GenerateSeed(this ModelBuilder modelBuilder)
        {
            var foodCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Food"
            };
            var clothesCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Сlothes"
            };

            modelBuilder.Entity<Category>().HasData(foodCategory, clothesCategory);
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Brownie",
                Price = 0.65M,
                StockQty = 48,
                ImageUrl = "https://images.unsplash.com/photo-1570145820259-b5b80c5c8bd6?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80",
                CategoryId = foodCategory.Id,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Muffin",
                Price = 1.00M,
                StockQty = 36,
                ImageUrl = "https://images.unsplash.com/photo-1607958996333-41aef7caefaa?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                CategoryId = foodCategory.Id,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Cake Pop",
                Price = 1.35M,
                StockQty = 24,
                ImageUrl = "https://images.unsplash.com/photo-1553786013-ad9531e591d4?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1135&q=80",
                CategoryId = foodCategory.Id,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple tart",
                Price = 1.50M,
                StockQty = 60,
                ImageUrl = "https://images.unsplash.com/photo-1584541305671-af4f46b4be2f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=965&q=80",
                CategoryId = foodCategory.Id,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Water",
                Price = 1.50M,
                StockQty = 30,
                ImageUrl = "https://images.unsplash.com/photo-1595994195534-d5219f02f99f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                CategoryId = foodCategory.Id,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Shirt",
                Price = 2.00M,
                StockQty = 5,
                ImageUrl = "https://images.unsplash.com/photo-1618354691373-d851c5c3a990?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=415&q=80",
                CategoryId = clothesCategory.Id,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Pants",
                Price = 3.00M,
                StockQty = 5,
                ImageUrl = "https://images.unsplash.com/photo-1542272604-787c3835535d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1026&q=80",
                CategoryId = clothesCategory.Id,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Jacket",
                Price = 4.00M,
                StockQty = 5,
                ImageUrl = "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=436&q=80",
                CategoryId = clothesCategory.Id,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Toy",
                Price = 2.00M,
                StockQty = 1,
                ImageUrl = "https://images.unsplash.com/photo-1582845512747-e42001c95638?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                CategoryId = clothesCategory.Id,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            });
        }
    }
}
