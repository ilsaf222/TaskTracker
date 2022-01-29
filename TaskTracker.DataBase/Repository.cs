using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain;
using TaskTracker.DataBase;

namespace TaskTracker.DataBase
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TaskTrackerContext context;
        private readonly DbSet<TEntity> dbSet;

        public Repository(TaskTrackerContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity item, CancellationToken cancellationToken)
        {
            dbSet.Add(item);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> items, CancellationToken cancellationToken)
        {
            dbSet.AddRange(items);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(TEntity item, CancellationToken cancellationToken)
        {
            dbSet.Remove(item);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity item, CancellationToken cancellationToken)
        {
            dbSet.Update(item);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
