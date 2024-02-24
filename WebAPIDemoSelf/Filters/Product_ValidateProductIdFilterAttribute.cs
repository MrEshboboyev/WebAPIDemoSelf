using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemoSelf.Models.Repositories;

namespace WebAPIDemoSelf.Filters
{
    public class Product_ValidateProductIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var productId = context.ActionArguments["productId"] as int?;

            if(productId.HasValue)
            {
                if (productId.Value <= 0)
                {
                    context.ModelState.AddModelError("Product", "ProductId is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!ProductRepository.ProductExists(productId.Value))
                {
                    context.ModelState.AddModelError("Product", "ProductId doesn't exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }

        }
    }
}
