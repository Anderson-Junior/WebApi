using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> PostUserAsync(User user);
    }
}
