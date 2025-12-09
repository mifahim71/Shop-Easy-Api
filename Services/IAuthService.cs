using ShopEasyApi.Dtos.AuthDtos;
using ShopEasyApi.Enums;

namespace ShopEasyApi.Services
{
    public interface IAuthService
    {
        Task<UserDto> CreateUserAsync(UserRegisterRequestDto requestDto, UserRole role);

        Task<JwtTokenDto> LoginUserAsync(AuthLoginRequestDto requestDto);
    }
}
