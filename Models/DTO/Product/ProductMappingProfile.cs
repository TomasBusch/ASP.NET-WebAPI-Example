using AutoMapper;


namespace WebAPI.Models.DTO.Product
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() { 
        
            CreateMap<Models.Product, GetProductDTO>();
            CreateMap<SetProductDTO, Models.Product>();
;        }
    }
}
