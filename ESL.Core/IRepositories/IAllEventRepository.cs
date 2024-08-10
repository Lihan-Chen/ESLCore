using ESL.Core.Models;

using System.Linq.Expressions;

namespace ESL.Core.IRepositories
{
    public interface IAllEventRepository // : IEventRepository<AllEvent>
    {
        #region Queries

        Task<IEnumerable<AllEvent>> GetAll(int facilNo);

        Task<IEnumerable<AllEvent>> GetDefaultAllEventsByFacil(int facilNo, DateTime startDate, DateTime endDate);

        Task<AllEvent> GetByEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo, AllEvent? allEvent);

        Task<IEnumerable<AllEvent>> FindEvents(Expression<Func<AllEvent, bool>> predicate);

        // Task<IEnumerable<AllEvent>> GetOutstandingEvents(int facilNo, int logTypeNo);

        // Task<IEnumerable<AllEvent>> GetAllEventsByFacilAndLogType(int facilNo, int logTypeNo, DateTime startDate, DateTime endDate);

        #endregion

        #region Commands

        //Task<bool> AddEvent(AllEvent allEvent);

        // Soft Delete
        //Task<bool> DeleteEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);

        // Mark the original entiry as revised or modified, and create a new entity with new revision number
        //Task<bool> Upsert(int facilNo, int logTypeNo, string eventID, int eventID_RevNo, AllEvent allEvent);

        #endregion

        

    }
}
