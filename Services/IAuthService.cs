using ShopEasyApi.Dtos.AuthDtos;
using ShopEasyApi.Enums;

namespace ShopEasyApi.Services
{
    public interface IAuthService
    {
        Task<UserDto> CreateUserAsync(UserRegisterRequestDto requestDto, UserRole role);
        Task<UserDto> GetByIdAsync(int userId);
        Task<JwtTokenDto> LoginUserAsync(AuthLoginRequestDto requestDto);
    }
}
