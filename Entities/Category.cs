namespace ShopEasyApi.Entities
{
    public class Category
    {
        public int Id { set; get; }

        public string Name { set; get; } = default!;

        public string Description { set; get; } = default!;

        public List<Product> Products { set; get; } = new List<Product>();
    }
}
