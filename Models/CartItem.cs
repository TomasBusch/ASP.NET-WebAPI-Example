namespace WebAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public required Cart Cart { get; set; }
        public int Count { get; set; }
        public required Product Product { get; set; }
    }
}
