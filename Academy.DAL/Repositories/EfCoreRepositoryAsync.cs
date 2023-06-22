using Academy.DAL.DataContext;
using Academy.DAL.Entities;
using Academy.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DAL.Repositories
{
    public class EfCoreRepositoryAsync<T> : IRepositoryAsync<T> where T : Entity
    {
        private readonly AppDbContext _dbContext;

        public EfCoreRepositoryAsync(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();

            return result;
        }

        public virtual async Task<T> GetAsync(int? id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);

            return result;
        }

        public  virtual async Task UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
