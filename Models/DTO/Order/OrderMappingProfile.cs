using AutoMapper;


namespace WebAPI.Models.DTO.Order
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile() { 
        
            CreateMap<Models.Order, GetOrderDTO>();
            CreateMap<SetOrderDTO, Models.Order>();
;        }
    }
}
