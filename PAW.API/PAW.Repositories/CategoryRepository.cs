using Microsoft.EntityFrameworkCore.Update;
using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category entity);
        Task<Category> CreateAsync(Category entity);
        Task<bool> DeleteAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Category entity);
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public async Task<Category> CreateAsync(Category entity)
        {
            bool success = await base.CreateAsync(entity);
            return success ? entity : null;
        }

        public async Task<Category> AddAsync(Category entity)
        {
            return await CreateAsync(entity);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await base.FindAsync(id);
            if (entity == null)
            {
                return false; 
            }
           
            return await base.DeleteAsync(entity);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var items = await base.ReadAsync();
            return items.ToList();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await base.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            return await base.UpdateAsync(entity);
        }
    }
}
