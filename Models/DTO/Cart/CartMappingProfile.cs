using AutoMapper;

namespace WebAPI.Models.DTO.Cart
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile() { 
        
            CreateMap<Models.Cart, GetCartDTO>();
            CreateMap<SetCartDTO, Models.Cart>();
;        }
    }
}
