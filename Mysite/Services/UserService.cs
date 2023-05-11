using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User Authenticate(string username, string password)
        {
            // Implementeer authenticatie logica
        }

        // Implementeer andere interface methoden...
    }
}