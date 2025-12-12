using Microsoft.EntityFrameworkCore;
using ShopEasyApi.Data;
using ShopEasyApi.Entities;

namespace ShopEasyApi.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<CartItem> AddCartItemAsync(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await SaveChangesAsync();
            return cartItem;
        }

        public async Task ClearCartAsync(int id)
        {
            await _context.CartItems.Where(ci => ci.CartId == id)
                .ExecuteDeleteAsync();
        }

        public async Task CreateCartAsync(Cart cart)
        {
             _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartByProductIdAsync(int cartId, int productId)
        {
            await _context.CartItems.Where(ci => ci.CartId == cartId && ci.ProductId == productId)
                .ExecuteDeleteAsync();
        }

        public async Task<Cart?> FindCartByUserIdAsync(int appUserId)
        {
            return await _context.Carts.AsNoTracking().FirstOrDefaultAsync(c => c.AppUserId == appUserId);
        }

        public async Task<Cart?> FindCartByUserIdWithItemAsync(int appUserId)
        {
            return await _context.Carts.AsNoTracking().Include(c => c.Items).FirstOrDefaultAsync(c => c.AppUserId == appUserId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
