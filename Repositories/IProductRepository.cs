using ShopEasyApi.Entities;

namespace ShopEasyApi.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product);

        Task DeleteProductAsync(Product product);

        Task SaveChangesAsync();

        Task<Product?> GetByIdTractingAsync(int id);
    }
}
