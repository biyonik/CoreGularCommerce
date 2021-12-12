using CoreGularCommerce.Core.Concrete;

namespace CoreGularCommerce.Core.Entities
{
    public class Product: BaseEntity 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
    }
}