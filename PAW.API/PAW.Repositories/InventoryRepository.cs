using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory> GetByIdAsync(int id);
        Task<Inventory> CreateAsync(Inventory inventory);
        Task<bool> UpdateAsync(Inventory inventory);
        Task<bool> DeleteAsync(int id);
    }
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            var items = await base.ReadAsync();
            return items.ToList();
        }
        public async Task<Inventory> GetByIdAsync(int id)
        {
            return await base.FindAsync(id);
        }
        public async Task<Inventory> CreateAsync(Inventory inventory)
        {
            var success = await base.CreateAsync(inventory);
            return success ? inventory : null;
        }
        public async Task<bool> UpdateAsync(Inventory inventory)
        {
            return await base.UpdateAsync(inventory);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await base.FindAsync(id);
            if (entity == null) return false;
            return await base.DeleteAsync(entity);
        }
    }
}