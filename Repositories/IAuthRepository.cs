using ShopEasyApi.Entities;
using System.Threading.Tasks;

namespace ShopEasyApi.Repositories
{
    public interface IAuthRepository
    {
        Task<AppUser> CreateUserAsync(AppUser user);

        Task<bool> EmailExistsAsync(string email);

        Task<bool> UserNameExistsAsync(string userName);

        Task<AppUser> GetByEmailAsync(string email);

    }
}
