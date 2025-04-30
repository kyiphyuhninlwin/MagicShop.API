using Magic_Shop.Models.Domain;

namespace Magic_Shop.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByID(int categoryID);
        Task<Category?> UpdateAsync(Category category);
        Task<Category?> DeleteAsync(int categoryID);
    }
}
