using Instagram.Data.Contexts;
using Instagram.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable
namespace Instagram.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly InstagramDbContext _dbContext;
        protected DbSet<T> _dbset;
        public GenericRepository(InstagramDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entry = await _dbset.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;

        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entry = await _dbset.FirstOrDefaultAsync(expression);
            if (entry == null)
                return false;
            _dbset.Remove(entry);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _dbset :  _dbset.Where(expression);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.FirstOrDefaultAsync(expression);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = _dbset.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }
    }
}

#pragma warning restore
