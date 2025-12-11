using ShopEasyApi.Enums;

namespace ShopEasyApi.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? HashPassword { get; set; }
        public UserRole Role { get; set; }
        public Cart? Cart { get; set; }
    }
}
