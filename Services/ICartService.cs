using ShopEasyApi.Dtos.CartDtos;

namespace ShopEasyApi.Services
{
    public interface ICartService
    {
        Task<CartItemDto> AddToCartAsync(int appUserId, AddToCartItemRequestDto requestDto);
        Task<CartDto> GetCartAsync(int appUserId);
    }
}
