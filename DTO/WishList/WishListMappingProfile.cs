using AutoMapper;


namespace WebAPI.DTO.WishList
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile() { 
        
            CreateMap<Models.WishList, GetWishListDTO>();
            CreateMap<SetWishListDTO, Models.WishList>();
            CreateMap<UpdateWishListDTO, Models.WishList>();
;        }
    }
}
