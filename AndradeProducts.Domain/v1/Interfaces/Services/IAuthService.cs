using AndradeProducts.Domain.DTOs.User;
using System.Threading.Tasks;

namespace AndradeProducts.Domain.v1.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(string userName, string password);
    }
}
