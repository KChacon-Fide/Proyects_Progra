using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
    public class ProductManager(IProductRepository productRepository, IFinanceService financeService) : IProductManager
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IFinanceService _financeService = financeService;
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.FindAsync(id);
        }
        public async Task<Product> CreateAsync(Product product)
        {
           
            return await _productRepository.CreateAsync(product);
        }
        public async Task<bool> UpdateAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}