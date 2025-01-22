using WebAPI.DTO.Cart;
using WebAPI.DTO.Product;

namespace WebAPI.DTO.CartItem
{
    public class SetCartItemDTO
    {
        public int Id { get; set; }
        public required GetCartDTO Cart { get; set; }
        public int Count { get; set; }
        public required GetProductDTO Product { get; set; }
    }
}
