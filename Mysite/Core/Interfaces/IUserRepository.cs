using Mysite.Core.Models;
using Mysite.Core.Interfaces;

    namespace Mysite.Core.IUserRepository
{
        public interface IUserRepository
        {
            Task<User> GetByIdAsync(int id);
            Task<IEnumerable<User>> GetAllAsync();
            Task<User> AddAsync(User user);
            Task UpdateAsync(User user);
            Task DeleteAsync(User user);
        }
    }
