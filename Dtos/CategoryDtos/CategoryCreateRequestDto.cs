using System.ComponentModel.DataAnnotations;

namespace ShopEasyApi.Dtos.CategoryDtos
{
    public class CategoryCreateRequestDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = default!;

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; } = default!;
    }
}
