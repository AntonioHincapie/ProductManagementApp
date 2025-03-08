namespace MyApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } // Store hashed passwords only
        public string? Role { get; set; } // Example: "Admin", "User"
    }
}