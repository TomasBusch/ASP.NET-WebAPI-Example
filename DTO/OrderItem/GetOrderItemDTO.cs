using WebAPI.DTO.Order;
using WebAPI.DTO.Product;

namespace WebAPI.DTO.OrderItem
{
    public class GetOrderItemDTO
    {
        public int Id { get; set; }
        public required GetOrderDTO Cart { get; set; }
        public int Count { get; set; }
        public required GetProductDTO Product { get; set; }
    }
}
