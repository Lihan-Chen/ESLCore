using System.Linq.Expressions;
using ESL.Core.IConfiguration;

namespace ESL.Core.IRepositories
{
    public interface IEventRepository
    {
        // This interface is for AllEvent class, not for any concrete log type which is based on ILogEventEntity
        public interface IEventRepository<TEntity> where TEntity : ILogEventEntity
        {
            #region Queries

            Task<IEnumerable<TEntity>> GetAll();

            Task<TEntity> GetByEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);

            Task<IEnumerable<TEntity>> FindEvent(Expression<Func<TEntity, bool>> predicate);

            Task<IEnumerable<TEntity>> GetOutstandingEvents(int facilNo, int logTypeNo);

            Task<IEnumerable<TEntity>> GetAllEvents(int facilNo, int logTypeNo, DateTime startDate, DateTime endDate);

            #endregion

            #region Commands

            Task<bool> AddEvent(TEntity entity);

            // Soft Delete
            Task<bool> DeleteEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);

            // Mark the original entiry as revised or modified, and create a new entity with new revision number
            Task<bool> Upsert(TEntity entity);

            #endregion
        }
    }
}
