using System.Linq.Expressions;
using ESL.Core.Models;
using ESL.Core.IConfiguration;

namespace ESL.Core.IRepositories
{
    // This interface is for any concrete log type which is based on ILogEventEntity,
    // not for AllEvent class which is based on IEventEntity.
    
    public interface ILogEventRepository<TEntity> where TEntity : ILogEventEntity
    {
        #region Queries

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Commands

        Task<bool> AddAsync(TEntity entity);

        Task<bool> DeleteAsync(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);

        Task<bool> UpsertAsync(TEntity entity);
        
        #endregion
    }
}
