using MyApp.Models;

namespace MyApp.Services
{
    public interface IUserService
    {
        User Register(User user);
        string Authenticate(string username, string password);
        void Logout();
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}