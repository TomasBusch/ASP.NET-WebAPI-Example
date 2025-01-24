using WebAPI.DTO.CartItem;

namespace WebAPI.DTO.Cart
{
    public class UpdateCartDTO
    {
        public int Id { get; set; }
        public IEnumerable<UpdateCartItemDTO>? Items { get; set; }
    }
}
