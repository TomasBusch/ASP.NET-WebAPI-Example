using AutoMapper;


namespace WebAPI.DTO.Order
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile() { 
        
            CreateMap<Models.Order, GetOrderDTO>()
                //.ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                ;
            CreateMap<SetOrderDTO, Models.Order>();
            CreateMap<UpdateOrderDTO, Models.Order>();
;        }
    }
}
