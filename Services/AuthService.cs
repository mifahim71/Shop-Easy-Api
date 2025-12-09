using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShopEasyApi.Dtos.AuthDtos;
using ShopEasyApi.Entities;
using ShopEasyApi.Repositories;
using ShopEasyApi.Exceptions;
using System.Security.Claims;
using ShopEasyApi.Enums;

namespace ShopEasyApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IMapper mapper, IAuthRepository authRepository, IJwtService jwtService)
        {
            _mapper = mapper;
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<UserDto> CreateUserAsync(UserRegisterRequestDto requestDto, UserRole role)
        {
            if (await _authRepository.EmailExistsAsync(requestDto.Email!) || await _authRepository.UserNameExistsAsync(requestDto.UserName!)) 
            {
                throw new DuplicateUserCredentialException("Email or UserName already exists");
            }

            var appUser = _mapper.Map<AppUser>(requestDto);
            appUser.Role = role;
            appUser.HashPassword = new PasswordHasher<AppUser>().HashPassword(appUser, requestDto.Password!);

            var savedUser = await _authRepository.CreateUserAsync(appUser);

            return _mapper.Map<UserDto>(savedUser);
        }

        public async Task<JwtTokenDto> LoginUserAsync(AuthLoginRequestDto requestDto)
        {
            var user = await _authRepository.GetByEmailAsync(requestDto.Email!);

            if (user == null)
            {
                throw new InvalidUserCredentialException("Invalid Email or Password");
            }

            var result = new PasswordHasher<AppUser>().VerifyHashedPassword(user, user.HashPassword!, requestDto.Password!);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new InvalidUserCredentialException("Invalid Email or Password");
            }

            string jwtToken = _jwtService.GenerateToken(new[]
                {
                    new Claim(ClaimTypes.Name, requestDto.Email!),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                });

            return new JwtTokenDto() { JwtToken = jwtToken };
        }
    }
}
