namespace WebAPI.Models.DTO.WishList
{
    public class SetCategoryDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public IEnumerable<int>? ProductIds { get; set; }
    }
}
