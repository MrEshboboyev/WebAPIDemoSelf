using Microsoft.AspNetCore.Mvc;
using WebAPIDemoSelf.Models;
using WebAPIDemoSelf.Models.Repositories;

namespace WebAPIDemoSelf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // get all entities
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok("Getting all products!");
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            if (productId <= 0)
                return BadRequest();

            var existingProduct = ProductRepository.GetProductById(productId);
            if(existingProduct == null)
                return NotFound();

            return Ok(existingProduct);
        }

        [HttpPost]
        // Postman [FromBody] : Body(Json)
        // Postman [FromForm] : Body(form-data)
        public IActionResult CreateProduct([FromBody] Product product)
        {
            return Ok("Create product.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"Updating product with ID : {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok($"Deleting product with ID : {id}");
        }
    }
}
