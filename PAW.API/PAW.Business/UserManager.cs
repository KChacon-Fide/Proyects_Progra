using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface IUserManager
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
    }
    public class UserManager(IUserRepository userRepository, IFinanceService financeService) : IUserManager
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IFinanceService _financeService = financeService;
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
        public async Task<User> CreateAsync(User user)
        {
            
            return await _userRepository.CreateAsync(user);
        }
        public async Task<bool> UpdateAsync(User user)
        {
            return await _userRepository.UpdateAsync(user);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}