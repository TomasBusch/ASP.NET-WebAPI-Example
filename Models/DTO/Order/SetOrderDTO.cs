using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.DTO.Order
{
    public class SetOrderDTO
    {
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime TransactionDateTime { get; set; }
        public required AppUser Buyer { get; set; }
        public required IEnumerable<OrderItem> Items { get; set; }
    }
}
