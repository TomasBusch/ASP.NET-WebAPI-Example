namespace WebAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public required Order Order { get; set; }
        public int Count { get; set; }
        public required Product Product { get; set; }
    }
}
