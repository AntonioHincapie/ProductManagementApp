using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;
using MyApp.Services;

namespace ProductsManagementApp.Pages.Categories
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }

    public class DetailsModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public Category Category { get; set; }

        public DetailsModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void OnGet(int id)
        {
            Category = _categoryService.GetCategoryById(id);
        }
    }

    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
    }

    public class EditModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}