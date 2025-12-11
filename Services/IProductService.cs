using ShopEasyApi.Dtos.ProductDtos;

namespace ShopEasyApi.Services
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(ProductCreateRequestDto requestDto);
        Task DeleteProductByIdAsync(int id);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<List<ProductDto>> GetProductByCategoryAsync(int categoryId);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<List<ProductDto>> GetProductByPriceRangeAsync(decimal minValue, decimal maxValue);
        Task UpdateProductAsync(int id, UpdateProductRequestDto requestDto);
    }
}
