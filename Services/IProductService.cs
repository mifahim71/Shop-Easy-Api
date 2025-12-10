using ShopEasyApi.Dtos.ProductDtos;

namespace ShopEasyApi.Services
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(ProductCreateRequestDto requestDto);
        Task<List<ProductDto>> GetAllProductsAsync();
    }
}
