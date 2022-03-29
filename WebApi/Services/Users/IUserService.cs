using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services.Users
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> PostUserAsync(User user);
        Task<User> GetUserAsync(string userName, string password);
    }
}
