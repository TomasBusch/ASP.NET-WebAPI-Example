using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.Product;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductsController : Controller
    {
        private ILogger Logger { get; set; }
        private IProductsService ProductsService { get; set; }

        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService) 
        { 
            Logger = logger;
            ProductsService = productsService;
        }


        // GET: Products/Search
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<GetProductDTO>>> Search([FromQuery] SearchProductDTO query)
        {
            return Ok(await ProductsService.getActiveProducts(query.Offset, query.Count));
        }

        // GET: Product
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDTO>> Get(int id)
        {
            GetProductDTO response;
            try
            {
                response = await ProductsService.getProductById(id);
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

        // GET: Products
        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] SetProductDTO product)
        {
            await ProductsService.createProduct(product);

            return Ok();
        }

        //// POST: ProductsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ProductsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ProductsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ProductsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ProductsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
