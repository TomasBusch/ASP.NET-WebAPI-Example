namespace WebAPI.DTO.Cart
{
    public class GetCartDTO
    {
        public int Id { get; set; }
        public IEnumerable<GetCartItemDTO>? Items { get; set; }
    }
}
