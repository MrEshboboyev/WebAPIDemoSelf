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
        public string GetProductById(int id)
        {
            return $"Getting product with ID : {id}";
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
