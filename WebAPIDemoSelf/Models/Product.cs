using System.ComponentModel.DataAnnotations;
using WebAPIDemoSelf.Models.Validations;

namespace WebAPIDemoSelf.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }

        // using own attribute
        [Product_EnsureCorrectSizing]
        public int? Size { get; set; }
        [Required]
        public string? Gender { get; set; }
        public double Price { get; set; }
    }
}
