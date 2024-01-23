using AndradeProducts.Domain.DTOs.User;
using AndradeProducts.Domain.Entities;
using AndradeProducts.Domain.v1.Interfaces.Repositories.Base;
using System.Threading.Tasks;

namespace AndradeProducts.Domain.v1.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> ValidateLoginAsync(string userName, string password);
    }
}
