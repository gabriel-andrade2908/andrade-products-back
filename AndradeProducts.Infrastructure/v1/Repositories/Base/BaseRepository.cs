using AndradeProducts.Domain.v1.Interfaces.Repositories.Base;
using AndradeProducts.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndradeProducts.Infrastructure.v1.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ProductsContext _context;
        protected readonly DbSet<TEntity> _dataSet;

        public BaseRepository(ProductsContext context)
        {
            _context = context;
            _dataSet = _context.Set<TEntity>();
        }

        public async Task AddNewAsync(TEntity model)
        {
            await _dataSet.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(int id)
        {
            return await _dataSet.FindAsync(id);
        }

        public async virtual Task<IEnumerable<TEntity>> GetManyAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public async Task UpdateAsync(TEntity model)
        {
            _dataSet.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity model)
        {
            _dataSet.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeveralAsync(IEnumerable<TEntity> objs)
        {
            foreach (var obj in objs)
                _dataSet.Remove(obj);

            await _context.SaveChangesAsync();
        }
    }
}
