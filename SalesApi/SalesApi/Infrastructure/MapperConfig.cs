using AutoMapper;
using SalesApi.DTOs;
using SalesApi.Entities;

namespace SalesApi.Infrastructure
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Category, CategoryDto>(MemberList.None)
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
            CreateMap<Product, ProductDto>(MemberList.None)
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
                .ForMember(d => d.StockQty, o => o.MapFrom(s => s.StockQty))
                .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ImageUrl))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.UpdatedAt))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedAt));
            CreateMap<OrderItemDto, OrderItem>(MemberList.None)
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId))
                .ForMember(d => d.Qty, o => o.MapFrom(s => s.Qty));

        }
    }
}
