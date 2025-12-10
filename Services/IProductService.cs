using ShopEasyApi.Dtos.ProductDtos;

namespace ShopEasyApi.Services
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(ProductCreateRequestDto requestDto);
        Task DeleteProductByIdAsync(int id);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task UpdateProductAsync(int id, UpdateProductRequestDto requestDto);
    }
}
