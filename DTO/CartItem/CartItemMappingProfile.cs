using AutoMapper;

namespace WebAPI.DTO.CartItem
{
    public class CartItemMappingProfile : Profile
    {
        public CartItemMappingProfile() { 
        
            CreateMap<Models.CartItem, GetCartItemDTO>();
            CreateMap<SetCartItemDTO, Models.CartItem>();
;        }
    }
}
