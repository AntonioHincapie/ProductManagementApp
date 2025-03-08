using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using MyApp.Services;
using Xunit;

namespace MyApp.Tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public void GetCategories_ReturnsAllCategories()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Categories.Add(new Category { Id = 1, Name = "Category 1" });
                context.Categories.Add(new Category { Id = 2, Name = "Category 2" });
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var service = new CategoryService(context);
                var categories = service.GetCategories();

                Assert.NotNull(categories);
                Assert.Equal(2, categories.Count());
            }
        }

        // [Fact]
        // public void GetCategoryById_ReturnsCategory()
        // {
        //     var options =new DbContextOptionsBuilder<AppDbContext>()
        //         .UseInMemoryDatabase(databaseName: "TestDb")
        //         .Options;

        //     using (var context = new AppDbContext(options))
        //     {
        //         var service = new CategoryService(context);
        //         var category = service.GetCategoryById(1);

        //         Assert.NotNull(category);
        //         Assert.Equal(1, category.Id);
        //     }
        // }

        [Fact]
        public void CreateCategory_AddsCategory()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new CategoryService(context);
                var category = new Category { Name = "New Category" };

                service.CreateCategory(category);

                Assert.Equal(3, category.Id);
            }
        }

        // [Fact]
        // public void UpdateCategory_UpdatesCategory()
        // {
        //     var options =new DbContextOptionsBuilder<AppDbContext>()
        //         .UseInMemoryDatabase(databaseName: "TestDb")
        //         .Options;

        //     using (var context = new AppDbContext(options))
        //     {
        //         var service = new CategoryService(context);
        //         var category = new Category { Id = 1, Name = "Updated Category" };

        //         service.UpdateCategory(category);

        //         var updatedCategory = context.Categories.Find(1);
        //         Assert.Equal("Updated Category", updatedCategory.Name);
        //     }
        // }

        [Fact]
        public void DeleteCategory_RemovesCategory()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new CategoryService(context);
                service.DeleteCategory(2);

                Assert.Equal(0, context.Categories.Count());
            }
        }
    }
}