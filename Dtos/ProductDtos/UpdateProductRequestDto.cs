using System.ComponentModel.DataAnnotations;

namespace ShopEasyApi.Dtos.ProductDtos
{
    public class UpdateProductRequestDto
    {
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }


        [StringLength(100, MinimumLength = 2)]
        public string? Description { get; set; }


        [Range(0, 100000, ErrorMessage = "Price must be between 0 and 100,000.00")]
        public decimal? Price { get; set; }


        [Range(0, 10000, ErrorMessage = "Stock must be between 0 and 10000")]
        public int? Stock { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0.")]
        public int? CategoryId { get; set; }
    }
}
