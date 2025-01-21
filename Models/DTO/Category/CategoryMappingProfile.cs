using AutoMapper;

namespace WebAPI.Models.DTO.Category
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile() { 
        
            CreateMap<Models.Category, GetCategoryDTO>();
            CreateMap<SetCategoryDTO, Models.Category>();
;        }
    }
}
