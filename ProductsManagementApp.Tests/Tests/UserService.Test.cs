using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using MyApp.Data;
using MyApp.Models;
using MyApp.Services;
using ProductsManagementApp.Configuration;
using Xunit;

namespace MyApp.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetUsers_ReturnsAllUsers()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Users.Add(new User { Id = 1, Username = "User 1", Password = "password", Role = "Admin" }); 
                context.Users.Add(new User { Id = 2, Username = "User 2", Password = "password", Role = "User" });
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var jwtSettings = Options.Create(new JwtSettings());
                var httpContextAccessor = new HttpContextAccessor();
                var service = new UserService(jwtSettings, context, httpContextAccessor);
                var users = service.GetUsers();

                Assert.NotNull(users);
                Assert.Equal(2, users.Count());
            }
        }

        [Fact]
        public void Register_AddsUser()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var jwtSettings = Options.Create(new JwtSettings());
                var httpContextAccessor = new HttpContextAccessor();
                var service = new UserService(jwtSettings, context, httpContextAccessor);
                var user = new User { Username = "User 1", Password = "password", Role = "Admin" };
                var registeredUser = service.Register(user);

                Assert.NotNull(registeredUser);
                Assert.Equal(3, registeredUser.Id);
            }
        }

        [Fact]
        public void UpdateUser_UpdatesUser()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var jwtSettings = Options.Create(new JwtSettings());
                var httpContextAccessor = new HttpContextAccessor();
                var service = new UserService(jwtSettings, context, httpContextAccessor);
                var user = new User { Id = 1, Username = "User 1 Updated", Role = "Admin" };
                service.UpdateUser(user);

                var updatedUser = context.Users.Find(1);
                Assert.NotNull(updatedUser);
                Assert.Equal("User 1 Updated", updatedUser.Username);
            }
        }

        [Fact]
        public void DeleteUser_RemovesUser()
        {
            var options =new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Users.Add(new User { Id = 1, Username = "User 1", Password = "password", Role = "Admin" });
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var jwtSettings = Options.Create(new JwtSettings());
                var httpContextAccessor = new HttpContextAccessor();
                var service = new UserService(jwtSettings, context, httpContextAccessor);
                service.DeleteUser(1);

                var deletedUser = context.Users.Find(1);
                Assert.Null(deletedUser);
            }
        }
    }    
}