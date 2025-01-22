using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.DTO.OrderItem;

namespace WebAPI.DTO.Order
{
    public class GetOrderDTO
    {
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime TransactionDateTime { get; set; }
        public required int BuyerId { get; set; }
        public required IEnumerable<GetOrderItemDTO> Items { get; set; }
    }
}
