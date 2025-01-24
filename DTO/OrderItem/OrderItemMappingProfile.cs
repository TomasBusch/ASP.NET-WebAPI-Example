using AutoMapper;

namespace WebAPI.DTO.OrderItem
{
    public class OrderItemMappingProfile : Profile
    {
        public OrderItemMappingProfile() { 
        
            CreateMap<Models.OrderItem, GetOrderItemDTO>();
            CreateMap<SetOrderItemDTO, Models.OrderItem>();
            CreateMap<UpdateOrderItemDTO, Models.OrderItem>();
;        }
    }
}
