using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace TaskTracker.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity item, CancellationToken cancellationToken);
        Task AddRangeAsync(IEnumerable<TEntity> items, CancellationToken cancellationToken);
        Task RemoveAsync(TEntity item, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity item, CancellationToken cancellationToken);
    }
}
