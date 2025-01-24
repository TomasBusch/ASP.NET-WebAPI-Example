using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Product;
using WebAPI.DTO.WishList;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class WishListController : Controller
    {
        private ILogger Logger { get; set; }
        private IWishListService WishListService { get; set; }

        public WishListController(ILogger<WishListController> logger, IWishListService wishlistService)
        {
            Logger = logger;
            WishListService = wishlistService;
        }


        // GET: Wishlist
        [Authorize]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<GetWishListDTO>>> Get()
        {
            return Ok(await WishListService.GetAllWishlists());
        }

        // GET: Wishlist/{id}
        [Authorize]
        [HttpGet("{wishlist_id}")]
        public async Task<ActionResult<GetWishListDTO>> Get([FromRoute] int wishlist_id)
        {
            GetWishListDTO response;
            try
            {
                response = await WishListService.getWishList(wishlist_id);
            }
            catch (Exception ex)
            {
                var customMessage = new
                {
                    Code = 500,
                    Message = "Internal Server Error",
                };

                return StatusCode(StatusCodes.Status500InternalServerError, customMessage);
            }

            return Ok(response);
            
        }

        // POST: Wishlist
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SetWishListDTO wishlist)
        {
            try
            {
                await WishListService.CreateWishlist(wishlist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [Authorize]
        [HttpPatch("{wishlist_id}")]
        public async Task<ActionResult<GetWishListDTO>> Update([FromBody] SetWishListDTO wishlist, [FromRoute] int wishlist_id)
        {
            try
            {
                await WishListService.UpdateWishlist(wishlist, wishlist_id);
            }catch (Exception ex)
            {
                return BadRequest("Incorrect product data");
            }
            
            return Ok();
        }

        [Authorize(Policy = "CanEditProducts")]
        [HttpDelete("{wishlist_id}")]
        public async Task<ActionResult<GetProductDTO>> Delete([FromRoute] int wishlist_id)
        {
            try
            {
                await WishListService.DeleteWishlist(wishlist_id);
            }
            catch (Exception ex)
            {
                return BadRequest("Incorrect data");
            }

            return Ok();
        }
    }
}
