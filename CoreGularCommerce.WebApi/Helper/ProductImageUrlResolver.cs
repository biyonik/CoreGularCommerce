using AutoMapper;
using CoreGularCommerce.Core.Entities;
using CoreGularCommerce.WebApi.DataTransformationObjects.Concrete;

namespace CoreGularCommerce.WebApi.Helper
{
    public class ProductImageUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;
        public ProductImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImagePath))
            {
                return $"{_configuration["ApiUrl"]}/{source.ImagePath}";
            }
            return null;
        }
    }
}