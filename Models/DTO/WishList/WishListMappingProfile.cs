using AutoMapper;


namespace WebAPI.Models.DTO.WishList
{
    public class WishListMappingProfile : Profile
    {
        public WishListMappingProfile() { 
        
            CreateMap<Models.WishList, GetWishListDTO>();
            CreateMap<SetWishListDTO, Models.WishList>();
;        }
    }
}
