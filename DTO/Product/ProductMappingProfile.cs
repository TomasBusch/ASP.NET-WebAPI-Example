using AutoMapper;
using WebAPI.Data_Access;


namespace WebAPI.DTO.Product
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() { 
        
            CreateMap<Models.Product, GetProductDTO>();
            CreateMap<SetProductDTO, Models.Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .IgnoreAllNull()
                ;
            CreateMap<UpdateProductDTO, Models.Product>();
;        }
    }
}
