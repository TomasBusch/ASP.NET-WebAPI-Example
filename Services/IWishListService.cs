using WebAPI.DTO.WishList;

namespace WebAPI.Services
{
    public interface IWishListService
    {

        public Task<GetWishListDTO> CreateWishlist(SetWishListDTO wishlist_dto);

        public Task<GetWishListDTO> DeleteWishlist(int wishlist_id);

        public Task<GetWishListDTO> UpdateWishlist(SetWishListDTO wishlist_dto, int wishlist_id);

        public Task<GetWishListDTO> getWishList(int wishlist_id);

        public Task<IEnumerable<GetWishListDTO>> GetAllWishlists();

        public Task<GetWishListDTO> AddProductToWishList(int product_id, int wishlist_id);

        public Task<GetWishListDTO> RemoveProductFromWishList(int product_id, int wishlist_id);

    }
}
