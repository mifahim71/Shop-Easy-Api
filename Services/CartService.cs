using AutoMapper;
using ShopEasyApi.Dtos.CartDtos;
using ShopEasyApi.Entities;
using ShopEasyApi.Exceptions;
using ShopEasyApi.Repositories;

namespace ShopEasyApi.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository ,IMapper mapper) 
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CartItemDto> AddToCartAsync(int appUserId, AddToCartItemRequestDto requestDto)
        {
            Cart cart = await _cartRepository.FindCartByUserIdAsync(appUserId);
            if (cart == null) 
            {
                throw new NotFoundException($"Cart with UserId:{appUserId} not found");
            }

            bool validProduct = await _productRepository.ProductExistsWithStockAsync(requestDto.ProductId, requestDto.Quantity);
            if (!validProduct) 
            {
                throw new NotFoundException("Invalid ProductId or less Quantity");
            }


            var cartItem = _mapper.Map<CartItem>(requestDto);
            cartItem.CartId = cart.Id;

            CartItem savedCartItem = await _cartRepository.AddCartItemAsync(cartItem);

            var cartItemDto = _mapper.Map<CartItemDto>(savedCartItem);

            return cartItemDto;

        }

        public async Task<CartDto> GetCartAsync(int appUserId)
        {

            Cart cart =  await _cartRepository.FindCartByUserIdWithItemAsync(appUserId);
            if (cart == null) 
            {
                throw new NotFoundException($"Cart with UserId:{appUserId} not found");
            }

            var cartItemDtos = _mapper.Map<List<CartItemDto>>(cart.Items);

            return new CartDto
            {
                Id = cart.Id,
                Items = cartItemDtos
            };
        }
    }
}
