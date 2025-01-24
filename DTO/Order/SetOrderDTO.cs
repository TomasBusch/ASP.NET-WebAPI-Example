using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.DTO.OrderItem;

namespace WebAPI.DTO.Order
{
    public class SetOrderDTO
    {
        public required IEnumerable<SetOrderItemDTO> Items { get; set; }
    }
}
