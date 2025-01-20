namespace WebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Count { get; set; }
        public int PriceInCents { get; set; }
        public string? Description {  get; set; }
        public IEnumerable<Tag>? Tags { get; set; }
        public required Category Category { get; set; }

        public IEnumerable<WishList>? wishLists { get; set; }
    }
}
