using AutoMapper;
using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Entities;
using CoreGularCommerce.Core.Specification.Concrete;
using CoreGularCommerce.WebApi.DataTransformationObjects.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreGularCommerce.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll()
        {
            var spec = new ProductMapSpecification();
            var products = await _productRepository.GetEntitiesWithSpecificationAsync(spec);
            if(products == null) {
                return NotFound();
            }
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductMapSpecification(id);
            var product = await _productRepository.GetEntityWithSpecificationAsync(spec);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Product, ProductDto>(product));
        }
    }
}