using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemoSelf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // get all entities
        [HttpGet]
        public string GetProducts()
        {
            return "Getting all products!";
        }

        [HttpGet("{id}")]
        // Route link : https://localhost:7112/api/products/4
        // Adding Key: Value in Request Header
        public string GetProductById(int id, [FromHeader(Name = "Color")] string color)
        {
            return $"Getting product with ID : {id}; Color : {color}";
        }

        [HttpPost]
        public string CreateProduct()
        {
            return "Create product.";
        }

        [HttpPut("{id}")]
        public string UpdateProduct(int id)
        {
            return $"Updating product with ID : {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteProduct(int id)
        {
            return $"Deleting product with ID : {id}";
        }
    }
}
