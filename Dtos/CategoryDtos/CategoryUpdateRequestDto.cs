using System.ComponentModel.DataAnnotations;

namespace ShopEasyApi.Dtos.CategoryDtos
{
    public class CategoryUpdateRequestDto
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }
    }
}
