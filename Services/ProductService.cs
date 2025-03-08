using MyApp.Data;
using MyApp.Models;

namespace MyApp.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts() => _context.Products.ToList();

        public Product GetProductById(int id) => _context.Products.Find(id);

        public void CreateProduct(Product product) 
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product) 
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id) 
        {
            var product = _context.Products.Find(id);
            if (product != null) {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}