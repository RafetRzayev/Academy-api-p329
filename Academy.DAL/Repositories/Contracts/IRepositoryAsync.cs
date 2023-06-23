using Academy.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DAL.Repositories.Contracts
{
    public interface IRepositoryAsync<T> where T : Entity
    {
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetByCondition(Expression<Func<T,bool>> predicate);
        Task<T> GetAsync(int? id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
