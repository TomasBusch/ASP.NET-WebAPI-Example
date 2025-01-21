using WebAPI.Models.DTO.Product;

namespace WebAPI.Models.DTO.WishList
{
    public class GetWishListDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public IEnumerable<GetProductDTO>? Products { get; set; }
    }
}
