namespace ShopEasyApi.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();

    }
}
