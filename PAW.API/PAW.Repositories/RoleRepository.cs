using PAW.Data.Repository;
using PAW.Models; 

namespace PAW.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role role);
        Task<bool> UpdateAsync(Role role);
        Task<bool> DeleteAsync(int id);
    }

    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var items = await base.ReadAsync();
            return items.ToList();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await base.FindAsync(id);
        }

        public async Task<Role> CreateAsync(Role role)
        {
            bool success = await base.CreateAsync(role);
            return success ? role : null;
        }

        public async Task<bool> UpdateAsync(Role role)
        {
            return await base.UpdateAsync(role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await base.FindAsync(id);
            if (existing == null) return false;

            return await base.DeleteAsync(existing);
        }
    }
}
