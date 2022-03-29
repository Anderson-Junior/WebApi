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
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> PostUserAsync(User user)
        {
            return await _userRepository.PostUserAsync(user);
        }
    }
}
