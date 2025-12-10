using ShopEasyApi.Dtos.CategoryDtos;

namespace ShopEasyApi.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateRequestDto requestDto);
        Task DeleteCategoryAsync(int categoryId);
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task<CategoryDto> UpdateCategoryAsync(int id, CategoryUpdateRequestDto requestDto);
    }
}
