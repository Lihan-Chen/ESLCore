using System.Linq.Expressions;
using ESL.Core.IConfiguration;

namespace ESL.Core.IRepositories
{
    public interface ILogRepository
    {
        public interface ILogRepository<TEntity> where TEntity : IBaseEvent
        {
            Task<IEnumerable<TEntity>> GetAllAsync();

            Task<TEntity> GetByIdAsync(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);

            Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

            Task<IEnumerable<TEntity>> GetOutstandingAsync(int facilNo, int logTypeNo);

            Task<IEnumerable<TEntity>> GetAllEventsAsync(int facilNo, int logTypeNo, DateTime startDate, DateTime endDate);

            Task<bool> AddAsync(TEntity entity);

            Task<bool> DeleteAsync(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);

            Task<bool> UpsertAsync(TEntity entity);
        }
    }
}
