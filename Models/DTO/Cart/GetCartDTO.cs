namespace WebAPI.Models.DTO.Cart
{
    public class GetCartDTO
    {
        public int Id { get; set; }
        public IEnumerable<CartItem>? Items { get; set; }
    }
}
