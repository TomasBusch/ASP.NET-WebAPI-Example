using AutoMapper;

namespace WebAPI.DTO.Category
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile() { 
        
            CreateMap<Models.Category, GetCategoryDTO>();
            CreateMap<SetCategoryDTO, Models.Category>();
;        }
    }
}
