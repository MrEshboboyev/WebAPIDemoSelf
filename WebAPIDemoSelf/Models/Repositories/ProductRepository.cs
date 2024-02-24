namespace WebAPIDemoSelf.Models.Repositories
{
    public static class ProductRepository
    {
        // products
        private static List<Product> products = new List<Product>
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

        public static List<Product> GetProducts() 
        { 
            return products; 
        }

        public static bool ProductExists(int id)
        {
            return products.Any(p => p.ProductId == id);
        }

        public static Product? GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.ProductId == id);
        }

        // get Product by properties
        public static Product? GetProductByProperties(string? brand, string? color, string? gender, int? size)
        {
            return products.FirstOrDefault(p =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(p.Brand) &&
            p.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(p.Color) &&
            p.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(p.Gender) &&
            p.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            p.Size.HasValue &&
            p.Size.Value == size.Value);
        }

        // add product
        public static void AddProduct(Product product)
        {
            int maxId = products.Max(p => p.ProductId);
            product.ProductId = maxId + 1;

            products.Add(product);
        }
    }
}
