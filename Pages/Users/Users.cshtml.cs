using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductsManagementApp.Pages.Users
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
    }

    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }
    }

    [Authorize (Roles = "Admin")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }

    [Authorize (Roles = "Admin")]
    public class EditModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}