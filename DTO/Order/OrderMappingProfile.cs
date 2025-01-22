using AutoMapper;


namespace WebAPI.DTO.Order
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile() { 
        
            CreateMap<Models.Order, GetOrderDTO>();
            CreateMap<SetOrderDTO, Models.Order>();
;        }
    }
}
