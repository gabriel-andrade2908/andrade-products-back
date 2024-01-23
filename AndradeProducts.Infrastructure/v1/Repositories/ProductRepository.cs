using AndradeProducts.Domain.Entities;
using AndradeProducts.Domain.v1.Interfaces.Repositories;
using AndradeProducts.Infrastructure.Context;
using AndradeProducts.Infrastructure.v1.Repositories.Base;

namespace AndradeProducts.Infrastructure.v1.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductsContext context) : base(context)
        {
        }
    }
}
