using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(int id);
        Task<Supplier> CreateAsync(Supplier supplier);
        Task<bool> UpdateAsync(Supplier supplier);
        Task<bool> DeleteAsync(int id);
    }

    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            var items = await base.ReadAsync();
            return items.ToList();
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            return await base.FindAsync(id);
        }

        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            bool success = await base.CreateAsync(supplier);  
            return success ? supplier : null;
        }

        public async Task<bool> UpdateAsync(Supplier supplier)
        {
            return await base.UpdateAsync(supplier);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await base.FindAsync(id);
            if (existing == null) return false;

            return await base.DeleteAsync(existing);
        }
    }
}
