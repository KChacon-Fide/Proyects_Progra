using Microsoft.EntityFrameworkCore.Update;
using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> FindAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await base.ReadAsync();
        }
        public async Task<Product> FindAsync(int id)
        {
            return await base.FindAsync(id);
        }
        public async Task<Product> CreateAsync(Product product)
        {
            bool success = await base.CreateAsync(product);
            return success ? product : null;
        }
        public async Task<bool> UpdateAsync(Product product)
        {
            return await base.UpdateAsync(product);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await base.FindAsync(id);
            if (existing == null) return false;

            return await base.DeleteAsync(existing);
        }
    }
}