using System.ComponentModel.DataAnnotations;

namespace ShopEasyApi.Dtos.CartDtos
{
    public class AddToCartItemRequestDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
