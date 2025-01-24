using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.WishList
{
    public class UpdateWishListDTO
    {
        [Required]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public IEnumerable<int>? ProductIds { get; set; }
    }
}
