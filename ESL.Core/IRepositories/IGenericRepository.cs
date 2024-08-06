using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.IRepositories
{
    internal interface IGenericRepository
    {
        public interface IGenericRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();

            Task<T> GetByIdAsync(int id);

            Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

            Task<bool> AddAsync(T entity);

            Task<bool> DeleteAsync(int id);

            Task<bool> UpsertAsync(T entity);
        }
    }
}
