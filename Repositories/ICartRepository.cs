using ShopEasyApi.Dtos.CartDtos;
using ShopEasyApi.Entities;

namespace ShopEasyApi.Repositories
{
    public interface ICartRepository
    {
        Task<CartItem> AddCartItemAsync(CartItem cartItem);
        Task CreateCartAsync(Cart cart);
        Task<Cart> FindCartByUserIdAsync(int appUserId);
        Task<Cart> FindCartByUserIdWithItemAsync(int appUserId);
        Task SaveChangesAsync();
    }
}
