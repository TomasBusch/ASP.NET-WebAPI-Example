namespace WebAPI.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public IEnumerable<CartItem>? Items { get; set; }
    }
}
