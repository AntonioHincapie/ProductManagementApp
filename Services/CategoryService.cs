using MyApp.Data;
using MyApp.Models;

namespace MyApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories() => _context.Categories.ToList();

        public Category GetCategoryById(int id) => _context.Categories.Find(id);

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null) {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}