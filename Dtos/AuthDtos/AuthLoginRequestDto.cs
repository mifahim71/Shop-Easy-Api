using System.ComponentModel.DataAnnotations;

namespace ShopEasyApi.Dtos.AuthDtos
{
    public class AuthLoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string? Password { get; set; }
    }
}
