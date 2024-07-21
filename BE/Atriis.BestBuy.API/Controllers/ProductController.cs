using BestBuy.Abstractions.Endpoints;
using BestBuy.Abstractions.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BestBuy.API.Controllers
{
    /// <summary>
    /// Product Controller
    /// </summary>
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [Route(Routes.ProductEndpoint)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductEndpoint _productEndpoint;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productEndpoint"></param>
        public ProductController(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        /// <summary>
        /// Get All Filtered Products
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpPost(Routes.GetAllFilteredProducts)]
        [ProducesResponseType(typeof(Abstractions.Models.FilteredProducts), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllFilteredProducts([FromBody] Abstractions.Models.TableFilters filters)
        {
            try
            {
                var operation = await _productEndpoint.GetAllFilteredProductsAsync(filters);
                return operation != null ? Ok(operation) : NotFound();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return BadRequest(ModelState);
            }
        }

    }
}
