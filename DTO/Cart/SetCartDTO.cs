using WebAPI.DTO.CartItem;

namespace WebAPI.DTO.Cart
{
    public class SetCartDTO
    {
        public int Id { get; set; }
        public IEnumerable<GetCartItemDTO>? Items { get; set; }
    }
}
