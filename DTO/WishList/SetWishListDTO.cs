namespace WebAPI.DTO.WishList
{
    public class SetWishListDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public IEnumerable<int>? ProductIds { get; set; }
    }
}
