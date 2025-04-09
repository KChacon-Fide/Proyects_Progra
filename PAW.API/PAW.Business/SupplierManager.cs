using PAW.Models;
using PAW.Repositories;  
using PAW.Services;      

namespace PAW.Business
{
    public interface ISupplierManager
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(int id);
        Task<Supplier> CreateAsync(Supplier supplier);
        Task<bool> UpdateAsync(Supplier supplier);
        Task<bool> DeleteAsync(int id);
    }
    public class SupplierManager(ISupplierRepository supplierRepository, IFinanceService financeService): ISupplierManager
    {
        private readonly ISupplierRepository _supplierRepository = supplierRepository;
        private readonly IFinanceService _financeService = financeService;
        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _supplierRepository.GetAllAsync();
        }
        public async Task<Supplier> GetByIdAsync(int id)
        {
            return await _supplierRepository.GetByIdAsync(id);
        }
        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            
            return await _supplierRepository.CreateAsync(supplier);
        }
        public async Task<bool> UpdateAsync(Supplier supplier)
        {
            return await _supplierRepository.UpdateAsync(supplier);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _supplierRepository.DeleteAsync(id);
        }
    }
}