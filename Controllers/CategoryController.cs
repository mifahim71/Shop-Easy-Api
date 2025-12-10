using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEasyApi.Dtos.CategoryDtos;
using ShopEasyApi.Services;

namespace ShopEasyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategoryAsync([FromBody] CategoryCreateRequestDto requestDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var categoryDto = await _categoryService.CreateCategoryAsync(requestDto);

            return Ok(categoryDto);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> UpdateCategoryAsync(int categoryId, [FromBody] CategoryUpdateRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryDto = await _categoryService.UpdateCategoryAsync(categoryId, requestDto);
            return Ok(categoryDto);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategoryAsync(int categoryId)
        {  
            await _categoryService.DeleteCategoryAsync(categoryId);
            return NoContent();
        }


        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategoriesAsync()
        {
            var categoryDtos = await _categoryService.GetAllCategoriesAsync();
            return Ok(categoryDtos);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryByIdAsync(int categoryId)
        {
            CategoryDto categoryDto = await _categoryService.GetCategoryByIdAsync(categoryId);
            return Ok(categoryDto);
        }

    }
}
