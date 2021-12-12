using CoreGularCommerce.Core.Entities;

namespace CoreGularCommerce.Core.Specification.Concrete
{
    public class ProductMapSpecification : BaseSpecification<Product>
    {
        public ProductMapSpecification()
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.ProductType);
        }

        public ProductMapSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.ProductType);
        }
    }
}