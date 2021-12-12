using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreGularCommerce.WebApi.Controllers
{
    public class BrandController : BaseApiController
    {

        private readonly IGenericRepository<Brand> _brandRepository;
        public BrandController(IGenericRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetAll() 
        {
            var brands = await _brandRepository.GetAllAsync();
            return Ok(brands);
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if(brand == null) {
                return NotFound();
            }
            return Ok(brand);
        }
    }
}