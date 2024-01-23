using AndradeProducts.Domain.DTOs.User;
using AndradeProducts.Domain.Entities;
using AndradeProducts.Domain.Helpers.Security;
using AndradeProducts.Domain.v1.Interfaces.Repositories;
using AndradeProducts.Infrastructure.Context;
using AndradeProducts.Infrastructure.v1.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AndradeProducts.Infrastructure.v1.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ProductsContext context) : base(context)
        {
        }

        public async Task<User> ValidateLoginAsync(string userName, string password)
        {
            return await _context.Users
                .Where(x => x.Password == Security.EncryptString(password) &&
                x.UserName == userName).FirstOrDefaultAsync();
        }
    }
}
