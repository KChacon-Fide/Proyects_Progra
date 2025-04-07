using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface IInventoryManager
    {
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory> GetByIdAsync(int id);
        Task<Inventory> CreateAsync(Inventory inventory);
        Task<bool> UpdateAsync(Inventory inventory);
        Task<bool> DeleteAsync(int id);
    }


    public class InventoryManager(IInventoryRepository inventoryRepository, IFinanceService financeService)
        : IInventoryManager
    {
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
        private readonly IFinanceService _financeService = financeService; 

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _inventoryRepository.GetAllAsync();
        }

        public async Task<Inventory> GetByIdAsync(int id)
        {
            return await _inventoryRepository.GetByIdAsync(id);
        }

        public async Task<Inventory> CreateAsync(Inventory inventory)
        {
            return await _inventoryRepository.CreateAsync(inventory);
        }

        public async Task<bool> UpdateAsync(Inventory inventory)
        {
            return await _inventoryRepository.UpdateAsync(inventory);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _inventoryRepository.DeleteAsync(id);
        }
    }
}
