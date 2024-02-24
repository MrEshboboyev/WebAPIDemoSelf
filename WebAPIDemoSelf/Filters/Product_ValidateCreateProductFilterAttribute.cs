using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemoSelf.Models;
using WebAPIDemoSelf.Models.Repositories;

namespace WebAPIDemoSelf.Filters
{
    public class Product_ValidateCreateProductFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var product = context.ActionArguments["product"] as Product;

            if (product == null)
            {
                context.ModelState.AddModelError("Product", "Product object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };

                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else 
            {
                var existingProduct = ProductRepository.GetProductByProperties(product.Brand, product.Color, product.Gender, product.Size);
                if (existingProduct != null)
                {
                    context.ModelState.AddModelError("Product", "Product already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
