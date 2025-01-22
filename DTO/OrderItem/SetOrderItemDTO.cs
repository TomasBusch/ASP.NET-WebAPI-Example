namespace WebAPI.DTO.OrderItem
{
    public class SetOrderItemDTO
    {
        public int Id { get; set; }
        public IEnumerable<SetOrderItemDTO>? Items { get; set; }
    }
}
