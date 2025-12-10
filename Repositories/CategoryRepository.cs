using Microsoft.EntityFrameworkCore;
using ShopEasyApi.Data;
using ShopEasyApi.Entities;

namespace ShopEasyApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }


        public async Task<Category?> FindCategoryByIdAsync(int id)
        {
            var category =  await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<bool> IfExistsById(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
