using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        #region Queries

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        #endregion

        #region Commands

        Task Add(T entity);

        // Soft Delete
        Task Delete(int id);

        // Update outgoing event, Add incoming event
        Task Upsert(T entity);

        #endregion
    }
}
