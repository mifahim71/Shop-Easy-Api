using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEasyApi.Dtos.CartDtos;
using ShopEasyApi.Services;
using System.Security.Claims;

namespace ShopEasyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize(Roles = "CUSTOMER, ADMIN")]
        [HttpPost]
        public async Task<ActionResult<CartDto>> AddToCartAsync([FromBody] AddToCartItemRequestDto requestDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            int appUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            CartItemDto cartItemDto = await _cartService.AddToCartAsync(appUserId, requestDto);
            return Ok(cartItemDto);
        }

        [Authorize(Roles = "CUSTOMER, ADMIN")]
        [HttpGet]
        public async Task<ActionResult<CartDto>> GetCartAsync()
        {
            var appUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            CartDto cartDto = await _cartService.GetCartAsync(appUserId);

            return cartDto;
        }
    }
}
