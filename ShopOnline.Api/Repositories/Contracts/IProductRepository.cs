using ShopOnline.Api.Entites;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetItem(int id);
        Task<ProductCategory> GetCategory(int id);

        Task<IEnumerable<Product>> GetItemsByCategory(int id);
        Task<IEnumerable<User>> GetUser(string userName, string password);
    }
}