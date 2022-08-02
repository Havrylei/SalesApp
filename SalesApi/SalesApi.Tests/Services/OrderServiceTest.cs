using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SalesApi.DTOs;
using SalesApi.Entities;
using SalesApi.Services;

namespace SalesApi.Tests.Services
{
    public class OrderServiceTest : BaseServiceTest
    {
        private readonly OrderService _orderService;

        public OrderServiceTest()
        {
            _orderService = new OrderService(_mapper, _dbContext);
        }

        [Fact]
        public async Task CreateOrder_ValidItem_CreatesOrder()
        {
            var categories = _fixture.CreateMany<Category>();

            await _dbContext.AddRangeAsync(categories);
            await _dbContext.SaveChangesAsync();

            var product = categories.First().Products.First(x => x.StockQty > 0);
            var qty = product.StockQty;
            var orderItemDtos = new List<OrderItemDto>
            {
                new OrderItemDto
                {
                    ProductId = product.Id,
                    Qty = qty
                }
            };

            await _orderService.CreateOrder(orderItemDtos);

            var createdOrder = await _dbContext.Orders.LastOrDefaultAsync();

            createdOrder.Should().NotBeNull();

            var orderItem = createdOrder.OrderItems.First();

            orderItem.ProductId.Should().Be(product.Id);
            orderItem.Qty.Should().Be(qty);
        }

        [Fact]
        public async Task CreateOrder_ValidItem_SelectedProductStockQtyBeZero()
        {
            var categories = _fixture.CreateMany<Category>();

            await _dbContext.AddRangeAsync(categories);
            await _dbContext.SaveChangesAsync();

            var product = categories.First().Products.First(x => x.StockQty > 0);
            var orderItemDtos = new List<OrderItemDto>
            {
                new OrderItemDto
                {
                    ProductId = product.Id,
                    Qty = product.StockQty
                }
            };

            await _orderService.CreateOrder(orderItemDtos);

            product.StockQty.Should().Be(0);
        }

        [Fact]
        public async Task CreateOrder_ItemsWithInvalidProducts_ThrowsException()
        {
            var orderItemDtos = _fixture.CreateMany<OrderItemDto>();

            var action = async () => await _orderService.CreateOrder(orderItemDtos);

            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task CreateOrder_ItemWithQtyMoreThanProductStockQty_ThrowsException()
        {
            var categories = _fixture.CreateMany<Category>();

            await _dbContext.AddRangeAsync(categories);
            await _dbContext.SaveChangesAsync();

            var product = categories.First().Products.First(x => x.StockQty > 0);
            var orderItemDtos = new List<OrderItemDto>
            {
                new OrderItemDto
                {
                    ProductId = product.Id,
                    Qty = product.StockQty + 1
                }
            };

            var action = async () => await _orderService.CreateOrder(orderItemDtos);

            await action.Should().ThrowAsync<ArgumentException>();
        }
    }
}
