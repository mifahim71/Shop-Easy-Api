using ShopEasyApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShopEasyApi.Dtos.AuthDtos
{
    public class UserRegisterRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? UserName {  get; set; }

        [Required]
        [StringLength (50, MinimumLength = 8)]
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public UserRole Role { get; set; }
    }
}
