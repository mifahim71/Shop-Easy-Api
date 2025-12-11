using ShopEasyApi.Entities;

namespace ShopEasyApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> CreateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
        Task<Category> FindCategoryByIdAsync(int id);
        Task SaveChangesAsync();
        Task<bool> IfExistsById(int id);
        Task<Category?> FindCategoryWithProductAsync(int categoryId);
    }
}
