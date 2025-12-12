namespace ShopEasyApi.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public int TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();


    }
}
