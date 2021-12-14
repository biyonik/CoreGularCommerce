using AutoMapper;
using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Entities;
using CoreGularCommerce.Core.Specification.Concrete;
using CoreGularCommerce.WebApi.DataTransformationObjects.Concrete;
using CoreGularCommerce.WebApi.Errors;
using CoreGularCommerce.WebApi.Helper;
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
        public async Task<ActionResult<Pagination<ProductDto>>> GetAll([FromQuery]ProductSpecParams specParams)
        {
            var spec = new ProductMapSpecification(specParams);
            var countSpec = new ProductCountSpecificationFilters(specParams);
            var totalItems = await _productRepository.CountAsync(countSpec);
            var products = await _productRepository.GetEntitiesWithSpecificationAsync(spec);
            var mappedData = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
            if(products == null) {
                return NotFound();
            }
            return Ok(new Pagination<ProductDto>(specParams.PageIndex, specParams.PageSize, totalItems, mappedData));
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