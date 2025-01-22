using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.DTO.OrderItem;

namespace WebAPI.DTO.Order
{
    public class SetOrderDTO
    {
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime TransactionDateTime { get; set; }
        public required int BuyerId { get; set; }
        public required IEnumerable<SetOrderItemDTO> Items { get; set; }
    }
}
