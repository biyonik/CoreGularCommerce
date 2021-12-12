using CoreGularCommerce.WebApi.DataTransformationObjects.Abstract;

namespace CoreGularCommerce.WebApi.DataTransformationObjects.Concrete
{
    public class ProductDto: IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
    }
}