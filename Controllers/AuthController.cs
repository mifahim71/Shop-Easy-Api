using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEasyApi.Dtos.AuthDtos;
using ShopEasyApi.Enums;
using ShopEasyApi.Services;

namespace ShopEasyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost("register-admin")]
        public async Task<ActionResult<UserDto>> CreateAdminAsync([FromBody] UserRegisterRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = await _authService.CreateUserAsync(requestDto, UserRole.ADMIN);

            return Ok(userDto);
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] UserRegisterRequestDto requestDto)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            var userDto = await _authService.CreateUserAsync(requestDto, UserRole.CUSTOMER);

            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<JwtTokenDto>> LoginUserAsync([FromBody] AuthLoginRequestDto requestDto) 
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return await _authService.LoginUserAsync(requestDto);
        }
    }
}
