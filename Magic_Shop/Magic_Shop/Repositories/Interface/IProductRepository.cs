using Magic_Shop.Models.Domain;

namespace Magic_Shop.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product?> GetByIdAsync(int productID);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> UpdateAsync(Product product);
        Task<Product?> DeleteAsync(int productID);
    }
}
