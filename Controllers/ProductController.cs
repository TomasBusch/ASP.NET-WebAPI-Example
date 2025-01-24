using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Product;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductController : Controller
    {
        private ILogger Logger { get; set; }
        private IProductsService ProductsService { get; set; }

        public ProductController(ILogger<ProductController> logger, IProductsService productsService)
        {
            Logger = logger;
            ProductsService = productsService;
        }


        // GET: Product/Search
        [AllowAnonymous]
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<GetProductDTO>>> Search([FromQuery] SearchProductDTO query)
        {
            return Ok(await ProductsService.getActiveProducts(query.Offset, query.Count));
        }

        // GET: Product/{id}
        [AllowAnonymous]
        [HttpGet("{product_id}")]
        public async Task<ActionResult<GetProductDTO>> Get([FromRoute] int product_id)
        {
            GetProductDTO response;
            try
            {
                response = await ProductsService.getProductById(product_id);
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

        // POST: Product
        [Authorize(Policy = "CanEditProduct")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SetProductDTO product)
        {
            await ProductsService.createProduct(product);

            return Ok();
        }

        [Authorize(Policy = "CanEditProduct")]
        [HttpPost("{product_id}/upload-image")]
        public async Task<ActionResult> Upload([FromRoute] int product_id, IFormFile file)
        {
            if (file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                Logger.LogInformation("FilePath: " + filePath);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok();
        }

        [Authorize(Policy = "CanEditProduct")]
        [HttpPatch("{product_id}")]
        public async Task<ActionResult<GetProductDTO>> Update([FromBody] SetProductDTO product, [FromRoute] int product_id)
        {
            try
            {
                await ProductsService.updateProduct(product, product_id);
            }catch (Exception ex)
            {
                return BadRequest("Incorrect product data");
            }
            
            return Ok();
        }

        [Authorize(Policy = "CanEditProducts")]
        [HttpDelete("{product_id}")]
        public async Task<ActionResult<GetProductDTO>> Delete([FromRoute] int product_id)
        {
            try
            {
                await ProductsService.deleteProduct(product_id);
            }
            catch (Exception ex)
            {
                return BadRequest("Incorrect data");
            }

            return Ok();
        }
    }
}
