using WebAPI.DTO.Product;

namespace WebAPI.DTO.OrderItem
{
    public class SetOrderItemDTO
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
    }
}
