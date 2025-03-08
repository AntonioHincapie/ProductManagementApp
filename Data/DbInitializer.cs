using MyApp.Models;

namespace MyApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                var products = new Product[]
                {
                    new Product { Name = "Product 1", Price = 10.99M, CategoryId = 1 },
                    new Product { Name = "Product 2", Price = 20.99M, CategoryId = 2 }
                };
                context.Products.AddRange(products);
            }

            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User { Username = "admin", Password = "admin123", Role = "Admin" },
                    new User { Username = "user", Password = "user123", Role = "User" }
                };
                context.Users.AddRange(users);
            }

            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category { Name = "Category 1" },
                    new Category { Name = "Category 2" }
                };
                context.Categories.AddRange(categories);
            }

            context.SaveChanges();
        }
    }
}