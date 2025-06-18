using ESL.Core.Interfaces;
using System.Linq.Expressions;

namespace ESL.Application.Interfaces.IRepositories
{
    // This interface is for any concrete log type which is based on ILogEventEntity,
    // not for AllEvent class which is based on IEventEntity.
    
    public interface ILogEventRepository<TEntity> where TEntity : ILogEventEntity
    {
        #region Queries

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Commands

        Task<bool> AddAsync(TEntity entity);

        Task<bool> DeleteAsync(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

        Task<bool> UpsertAsync(TEntity entity);
        
        #endregion
    }
}
