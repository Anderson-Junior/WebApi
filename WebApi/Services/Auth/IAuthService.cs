using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services.Auth
{
    public interface IAuthService
    {
        Task<string> Authenticate(User user);
    }
}
