using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface ICategoryManager
    {
        Task<List<Category>> ReadAllAsync();

        Task<Category> GetByIdAsync(int id);

        Task<Category> CreateAsync(Category entity);

        Task<bool> UpdateAsync(Category entity);

        Task<bool> DeleteAsync(int id);
    }

    public class CategoryManager(ICategoryRepository categoryRepository, IFinanceService financeService) : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IFinanceService _financeService = financeService;

        
        public async Task<List<Category>> ReadAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            
            var newEntity = await _categoryRepository.AddAsync(entity);
            return newEntity;
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            return await _categoryRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }
    }
}
