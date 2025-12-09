using System.Security.Claims;

namespace ShopEasyApi.Services
{
    public interface IJwtService
    {
        string GenerateToken(IEnumerable<Claim>? claims = null);
    }
}
