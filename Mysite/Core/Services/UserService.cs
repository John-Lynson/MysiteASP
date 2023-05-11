using Mysite.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mysite.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<User> CreateAsync(User user);
        Task<User> GetByEmailAsync(string email);
    }
}
