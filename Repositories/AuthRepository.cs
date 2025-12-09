using Microsoft.EntityFrameworkCore;
using ShopEasyApi.Data;
using ShopEasyApi.Entities;

namespace ShopEasyApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> CreateUserAsync(AppUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> EmailExistsAsync(string email) =>
            await _context.Users.AnyAsync(u => u.Email == email);

        public async Task<bool> UserNameExistsAsync(string userName) =>
            await _context.Users.AnyAsync(u => u.UserName == userName);

        public async Task<AppUser?> GetByEmailAsync(string email) =>
            await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        

    }
}
