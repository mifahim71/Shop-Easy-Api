using ShopEasyApi.Entities;

namespace ShopEasyApi.Dtos.CartDtos
{
    public class CartItemDto
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
