using AutoMapper;


namespace WebAPI.Models.DTO.Tag
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile() { 
        
            CreateMap<Models.Tag, GetTagDTO>();
            CreateMap<SetTagDTO, Models.Tag>();
;        }
    }
}
