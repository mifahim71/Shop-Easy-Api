using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEasyApi.Dtos.ProductDtos;
using ShopEasyApi.Services;

namespace ShopEasyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProductAsync([FromBody] ProductCreateRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductDto productDto = await _productService.CreateProductAsync(requestDto);
            return Ok(productDto);

        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProductsAsync([FromQuery] int? categoryId)
        {
            if (categoryId.HasValue)
            {
                return await _productService.GetProductByCategoryAsync(categoryId.Value);
            }
            var productDtos = await _productService.GetAllProductsAsync();
            return productDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductAsync(int id) 
        {
            var productDto = await _productService.GetProductByIdAsync(id);
            return Ok(productDto);
        }


        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            await _productService.DeleteProductByIdAsync(id);
            return NoContent();
        }


        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProductAsync(int id, [FromBody] UpdateProductRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productService.UpdateProductAsync(id, requestDto);
            return NoContent();            
        }


        [HttpGet("price")]
        public async Task<ActionResult<ProductDto>> GetProductByPriceRangeAsync([FromQuery] decimal? minValue, [FromQuery] decimal? maxValue)
        {
            
            if (!minValue.HasValue)
            {
                
                minValue = 0;
            }
            if (!maxValue.HasValue)
            {
                
                maxValue = 1000;
            }

            List<ProductDto> productDtos = await _productService.GetProductByPriceRangeAsync(minValue.Value, maxValue.Value);
            return Ok(productDtos);
        }
    }
}
