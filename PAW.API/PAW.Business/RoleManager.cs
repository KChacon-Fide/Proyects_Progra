using PAW.Models;       
using PAW.Repositories; 
using PAW.Services;     

namespace PAW.Business
{
    public interface IRoleManager
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role role);
        Task<bool> UpdateAsync(Role role);
        Task<bool> DeleteAsync(int id);
    }

    public class RoleManager(IRoleRepository roleRepository, IFinanceService financeService) : IRoleManager
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IFinanceService _financeService = financeService;

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<Role> CreateAsync(Role role)
        {
            return await _roleRepository.CreateAsync(role);
        }

        public async Task<bool> UpdateAsync(Role role)
        {
            return await _roleRepository.UpdateAsync(role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _roleRepository.DeleteAsync(id);
        }
    }
}
