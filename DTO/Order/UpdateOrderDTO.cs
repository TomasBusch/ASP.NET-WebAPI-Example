using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.DTO.OrderItem;

namespace WebAPI.DTO.Order
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public required IEnumerable<UpdateOrderItemDTO> Items { get; set; }
    }
}
