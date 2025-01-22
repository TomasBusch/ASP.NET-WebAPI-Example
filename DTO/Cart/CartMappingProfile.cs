using AutoMapper;

namespace WebAPI.DTO.Cart
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile() { 
        
            CreateMap<Models.Cart, GetCartDTO>();
            CreateMap<SetCartDTO, Models.Cart>();
;        }
    }
}
