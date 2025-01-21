using AutoMapper;


namespace WebAPI.Models.DTO.WishList
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile() { 
        
            CreateMap<Models.WishList, GetWishListDTO>();
            CreateMap<SetCategoryDTO, Models.WishList>();
;        }
    }
}
