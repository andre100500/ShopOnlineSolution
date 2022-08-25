using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entites;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _context;

        public ProductRepository(ShopOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await _context.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await _context.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await _context.Products.Include(p=>p.ProductCategory).SingleOrDefaultAsync(c=> c.Id == id);
            return product;
        }

        public async  Task<IEnumerable<Product>> GetItems()
        {
            var products = await _context.Products.
                Include(p => p.ProductCategory).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            var products = _context.Products.
                Include(p => p.ProductCategory)
                .Where(p => p.Id == id).ToListAsync();
            return (IEnumerable<Product>)products;
        }

        public async Task<IEnumerable<User>> GetUser(string userName, string password)
        {
            var products = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
            return (IEnumerable<User>)products;
        }

    }
}

