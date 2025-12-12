using ShopEasyApi.Dtos.CartDtos;

namespace ShopEasyApi.Services
{
    public interface ICartService
    {
        Task<CartItemDto> AddToCartAsync(int appUserId, AddToCartItemRequestDto requestDto);
        Task ClearCartAsync(int appUserId);
        Task DeleteCartByProductIdAsync(int appUserId, int productId);
        Task<CartDto> GetCartAsync(int appUserId);
    }
}
