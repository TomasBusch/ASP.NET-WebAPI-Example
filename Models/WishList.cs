namespace WebAPI.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
