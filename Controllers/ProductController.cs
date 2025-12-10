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

    }
}
