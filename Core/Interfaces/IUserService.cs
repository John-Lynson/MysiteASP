using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(string email, string password);
        Task<User> AuthenticateUserAsync(string email, string password);
        Task<bool> SignOutUserAsync(string userId);
        Task<bool> ResetPasswordAsync(string email);
    }
}
