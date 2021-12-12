using CoreGularCommerce.Core.Entities;

namespace CoreGularCommerce.Core.Specification.Concrete
{
    public class ProductCountSpecificationFilters: BaseSpecification<Product>
    {
        public ProductCountSpecificationFilters(ProductSpecParams specParams)
        : base(x => 
            (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
            (!(specParams.BrandId != null) || x.BrandId == specParams.BrandId) && 
            (!(specParams.ProductTypeId != null) || x.ProductTypeId == specParams.ProductTypeId))
        {
        }
    }
}