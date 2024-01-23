using AndradeProducts.Domain.Entities;
using AndradeProducts.Domain.v1.Interfaces.Repositories.Base;

namespace AndradeProducts.Domain.v1.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
