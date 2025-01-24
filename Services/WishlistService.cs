using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAPI.Data_Access;
using WebAPI.DTO.WishList;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class WishlistService : IWishListService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WishlistService(ILogger<ProductsService> logger, IUnitOfWork unitOfWork, IMapper mapper,UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<GetWishListDTO> AddProductToWishList(int product_id, int wishlist_id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetWishListDTO> CreateWishlist(SetWishListDTO wishlist_dto)
        {
            WishList list = _mapper.Map<WishList>(wishlist_dto);

            List<Product> products = new List<Product>();

            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId == null)
            {
                throw new Exception("User not found");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (wishlist_dto.ProductIds != null)
            {

                foreach (int productId in wishlist_dto.ProductIds)
                {
                    var product = await _unitOfWork.ProductRepository.GetById(productId);

                    if (product != null)
                    {
                        products.Add(product);
                    }
                }
            }

            list.Products = products;

            if( user.WishLists == null)
            {
                user.WishLists = new List<WishList>();
            }

            var WishlistList = user.WishLists.ToList();
            WishlistList.Add(list);

            user.WishLists = WishlistList;
            
            await _userManager.UpdateAsync(user);
            await _unitOfWork.Save();

            return _mapper.Map<GetWishListDTO>(list);
        }

        public async Task<GetWishListDTO> DeleteWishlist(int wishlist_id)
        {
            var wishlist = await _unitOfWork.WishlistRepository.GetById(wishlist_id);

            if (wishlist == null)
            {
                throw new Exception("wishlist not found");
            }

            var response = _mapper.Map<GetWishListDTO>(wishlist);
            
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                throw new Exception("User not found");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if(user.WishLists == null)
            {
                throw new Exception("Wishlist not found");
            }

            if (user.WishLists.Contains(wishlist))
            {
                await _unitOfWork.WishlistRepository.Delete(wishlist);
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Wishlist not found");
            }

            return response;
        }

        public async Task<IEnumerable<GetWishListDTO>> GetAllWishlists()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                throw new Exception("User not found");
            }

            var user = _userManager.Users.Include(u => u.WishLists).Where(u => u.Id == userId).ToList().First();

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.WishLists == null)
            {
                throw new Exception("Wishlist not found");
            }

            List<GetWishListDTO> wishlists = _mapper.Map<List<GetWishListDTO>>(user.WishLists);

            return wishlists;
        }

        public async Task<GetWishListDTO> getWishList(int wishlist_id)
        {
            var wishlist = await _unitOfWork.WishlistRepository.GetById(wishlist_id);

            if (wishlist == null)
            {
                throw new Exception("wishlist not found");
            }

            var response = _mapper.Map<GetWishListDTO>(wishlist);

            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                throw new Exception("User not found");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.WishLists == null)
            {
                throw new Exception("Wishlist not found");
            }

            if (user.WishLists.Contains(wishlist))
            {
                return response;
            }
            else
            {
                throw new Exception("Wishlist not found");
            }
        }

        public Task<GetWishListDTO> RemoveProductFromWishList(int product_id, int wishlist_id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetWishListDTO> UpdateWishlist(SetWishListDTO wishlist_dto, int wishlist_id)
        {
            var wishlist = await _unitOfWork.WishlistRepository.GetById(wishlist_id);

            if (wishlist == null)
            {
                throw new Exception("wishlist not found");
            }

            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                throw new Exception("User not found");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.WishLists == null)
            {
                throw new Exception("Wishlist not found");
            }

            if (user.WishLists.Contains(wishlist))
            {

                _mapper.Map(wishlist_dto, wishlist);
                await _unitOfWork.WishlistRepository.Update(wishlist);
                await _unitOfWork.Save();

                var response = _mapper.Map<GetWishListDTO>(wishlist);
                return response;
            }
            else
            {
                throw new Exception("Wishlist not found");
            }
        }
    }
}
