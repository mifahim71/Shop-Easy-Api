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

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
        public async Task<ActionResult<List<ProductDto>>> GetAllProductsAsync()
        {
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


    }
}
