using System.ComponentModel.DataAnnotations;

namespace WebAPIDemoSelf.Models.Validations
{
    public class Product_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;

            if(product != null && !string.IsNullOrWhiteSpace(product.Gender))
            {
                if(product.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && product.Size < 8)
                {
                    return new ValidationResult("For men's products, the size has to be greater or equal to 8");
                }
                
                else if(product.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && product.Size < 6)
                {
                    return new ValidationResult("For women's products, the size has to be greater or equal to 6");
                }
            }

            return ValidationResult.Success;
        }
    }
}
