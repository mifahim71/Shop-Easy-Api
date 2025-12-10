using Microsoft.EntityFrameworkCore;
using ShopEasyApi.Data;
using ShopEasyApi.Entities;

namespace ShopEasyApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await SaveChangesAsync();

            return await GetByIdAsync(product.Id);
        }

        public async Task DeleteProductAsync(Product product)
        {
            _context?.Products.Remove(product);
            await SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().Include(p => p.Category).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking().Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> GetByIdTractingAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
