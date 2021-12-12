using CoreGularCommerce.Core.Entities;

namespace CoreGularCommerce.Core.Specification.Concrete
{
    public class ProductMapSpecification : BaseSpecification<Product>
    {
        public ProductMapSpecification(ProductSpecParams specParams)
        : base(x => 
            (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
            (!(specParams.BrandId != null) || x.BrandId == specParams.BrandId) && 
            (!(specParams.ProductTypeId != null) || x.ProductTypeId == specParams.ProductTypeId))
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyingPaging(specParams.PageSize * (specParams.PageIndex-1), specParams.PageSize);
            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    case "brandAsc":
                        AddOrderBy(x => x.Brand.Name);
                        break;
                    case "brandDesc":
                        AddOrderByDescending(x => x.Brand.Name);
                        break;
                    case "productTypeAsc":
                        AddOrderBy(x => x.ProductType.Name);
                        break;
                    case "productTypeDesc":
                        AddOrderByDescending(x => x.ProductType.Name);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductMapSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.ProductType);
        }
    }
}