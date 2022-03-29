using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories.Users;

namespace WebApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserAsync(string userName, string password)
        {
            var user = await _userRepository.GetUserAsync(userName, password);
            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> PostUserAsync(User user)
        {
            var usuario = await _userRepository.PostUserAsync(user);
            return usuario;
        }
    }
}
