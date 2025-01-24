using WebAPI.DTO.CartItem;

namespace WebAPI.DTO.Cart
{
    public class SetCartDTO
    {
        public IEnumerable<SetCartItemDTO>? Items { get; set; }
    }
}
