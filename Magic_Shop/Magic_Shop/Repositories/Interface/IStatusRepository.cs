using Magic_Shop.Models.Domain;

namespace Magic_Shop.Repositories.Interface
{
    public interface IStatusRepository
    {
        Task<Status> CreateAsync(Status status);
        Task<IEnumerable<Status>> GetAllAsync();
        Task<Status?> GetByID(int statusID);
        Task<Status?> UpdateAsync(Status status);
        Task<Status?> DeleteAsync(int statusID);
    }
}
