using AutoMapper;


namespace WebAPI.DTO.Tag
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile() { 
        
            CreateMap<Models.Tag, GetTagDTO>();
            CreateMap<SetTagDTO, Models.Tag>();
            CreateMap<UpdateTagDTO, Models.Tag>();
;        }
    }
}
