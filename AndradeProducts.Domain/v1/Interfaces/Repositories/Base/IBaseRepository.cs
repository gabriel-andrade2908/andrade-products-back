using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndradeProducts.Domain.v1.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetManyAsync();
        Task AddNewAsync(TEntity model);
        Task UpdateAsync(TEntity model);
        Task DeleteAsync(TEntity model);
        Task DeleteSeveralAsync(IEnumerable<TEntity> objs);
    }
}
