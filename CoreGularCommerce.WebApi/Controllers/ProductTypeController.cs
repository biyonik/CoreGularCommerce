using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreGularCommerce.WebApi.Controllers
{
    public class ProductTypeController : BaseApiController
    {

        private readonly IGenericRepository<ProductType> _productTypeRepository;
        public ProductTypeController(IGenericRepository<ProductType> productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAll() 
        {
            var productTypes = await _productTypeRepository.GetAllAsync();
            return Ok(productTypes);
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
            var productType = await _productTypeRepository.GetByIdAsync(id);
            if(productType == null) {
                return NotFound();
            }
            return Ok(productType);
        }
    }
}