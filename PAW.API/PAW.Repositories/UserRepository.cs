using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var items = await base.ReadAsync(); 
            return items.ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await base.FindAsync(id); 
        }

        public async Task<User> CreateAsync(User user)
        {
            bool success = await base.CreateAsync(user); 
            return success ? user : null;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            return await base.UpdateAsync(user); 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await base.FindAsync(id);
            if (existing == null) return false;

            return await base.DeleteAsync(existing); 
        }
    }
}
