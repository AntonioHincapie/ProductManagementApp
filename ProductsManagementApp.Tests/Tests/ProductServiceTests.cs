using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetProducts_ReturnsAllProducts()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Products.Add(new Product { Id = 1, Name = "Product 1", Price = 10.99M, CategoryId = 1 });
                context.Products.Add(new Product { Id = 2, Name = "Product 2", Price = 20.99M, CategoryId = 2 });
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var service = new ProductService(context);
                var products = service.GetProducts();

                Assert.NotNull(products);
                Assert.Equal(2, products.Count());
            }
        }

        [Fact]
        public void GetProductById_ReturnsProduct()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new ProductService(context);
                var product = service.GetProductById(1);

                Assert.NotNull(product);
                Assert.Equal(1, product.Id);
            }
        }

        [Fact]
        public void CreateProduct_AddsProduct()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new ProductService(context);
                var product = new Product { Name = "New Product", Price = 30.99M, CategoryId = 1 };

                service.CreateProduct(product);

                Assert.Equal(2, context.Products.Count());
            }
        }

        [Fact]
        public void UpdateProduct_UpdatesProduct()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new ProductService(context);
                var product = new Product { Id = 1, Name = "Updated Product", Price = 20.99M, CategoryId = 1 };

                service.UpdateProduct(product);

                var updatedProduct = context.Products.Find(1);
                Assert.Equal("Updated Product", updatedProduct.Name);
            }
        }

        [Fact]
        public void DeleteProduct_RemovesProduct()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new ProductService(context);
                service.DeleteProduct(2);

                Assert.Equal(1, context.Products.Count());
            }
        }
    }
}