using Microsoft.AspNetCore.Mvc;
using WebAPIDemoSelf.Models;

namespace WebAPIDemoSelf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // products
        // shirts
        private List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, Brand = "Nike", Color = "Red", Size = 10, Gender = "Men", Price = 29.99 },
            new Product { ProductId = 2, Brand = "Adidas", Color = "Blue", Size = 19, Gender = "Women", Price = 34.99 },
            new Product { ProductId = 3, Brand = "Puma", Color = "Green", Size = 9, Gender = "Men", Price = 24.99 },
            new Product { ProductId = 4, Brand = "Under Armour", Color = "Black", Size = 11, Gender = "Women", Price = 39.99 },
            new Product { ProductId = 5, Brand = "Reebok", Color = "White", Size = 10, Gender = "Men", Price = 27.99 },
            new Product { ProductId = 6, Brand = "New Balance", Color = "Gray", Size = 9, Gender = "Women", Price = 31.99 },
            new Product { ProductId = 7, Brand = "Fila", Color = "Yellow", Size = 8, Gender = "Men", Price = 22.99 },
            new Product { ProductId = 8, Brand = "Asics", Color = "Purple", Size = 18, Gender = "Women", Price = 36.99 },
            new Product { ProductId = 9, Brand = "Converse", Color = "Orange", Size = 11, Gender = "Men", Price = 26.99 },
            new Product { ProductId = 10, Brand = "Vans", Color = "Pink", Size = 10, Gender = "Women", Price = 29.99 }
        };

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

            var existingProduct = products.FirstOrDefault(x => x.ProductId == productId);
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
