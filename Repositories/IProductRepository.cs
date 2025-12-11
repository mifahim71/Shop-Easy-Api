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

        Task<List<Product>> GetProductByPriceRangeAsync(decimal minValue, decimal maxValue);
        Task<bool> ProductExistsWithStockAsync(int productId, int quantity);
        Task UpdateStockAsync(int productId, int quantity);
    }
}
