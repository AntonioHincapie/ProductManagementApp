using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;
using MyApp.Services;

namespace ProductsManagementApp.Pages.Products
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
        private readonly IProductService _productService;

        public Product Product { get; set; }

        public DetailsModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet(int id)
        {
            Product = _productService.GetProductById(id);
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