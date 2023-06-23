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

        public virtual async Task<int> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            if (entity == null) return -1;

            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();   

            return entity.Id;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();

            return result;
        }

        public virtual async Task<T> GetAsync(int? id)
        {
            var result = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public  virtual async Task UpdateAsync(T entity)
        {
            var existEntity = await GetAsync(entity.Id);
          
            //existEntity = entity;
           
            if (existEntity is null) throw new Exception("Not found");

            _dbContext.Set<T>().Update(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
