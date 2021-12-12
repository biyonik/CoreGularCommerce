using AutoMapper;
using CoreGularCommerce.Core.Entities;
using CoreGularCommerce.WebApi.DataTransformationObjects.Concrete;

namespace CoreGularCommerce.WebApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.ImagePath, o => o.MapFrom<ProductImageUrlResolver>())
            .ReverseMap();
        }
    }
}