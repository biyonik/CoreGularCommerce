using AutoMapper;
using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Entities;
using CoreGularCommerce.Core.Specification.Concrete;
using CoreGularCommerce.WebApi.DataTransformationObjects.Concrete;
using CoreGularCommerce.WebApi.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CoreGularCommerce.WebApi.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductMapSpecification(id);
            var product = await _productRepository.GetEntityWithSpecificationAsync(spec);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(_mapper.Map<Product, ProductDto>(product));
        }
    }
}