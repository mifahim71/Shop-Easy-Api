using ShopEasyApi.Dtos.AuthDtos;

namespace ShopEasyApi.Services
{
    public interface IAuthService
    {
        Task<UserDto> CreateUserAsync(UserRegisterRequestDto requestDto);

        Task<JwtTokenDto> LoginUserAsync(AuthLoginRequestDto requestDto);
    }
}
