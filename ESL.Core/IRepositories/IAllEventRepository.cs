using ESL.Core.Models.BusinessEntities;
using System.Linq.Expressions;

namespace ESL.Core.IRepositories
{
    public interface IAllEventRepository // : IEventRepository<AllEvent>
    {
        #region Queries

        Task<IEnumerable<AllEvent>> GetAll(int FacilNo);

        Task<IEnumerable<AllEvent>> GetDefaultAllEventsByFacil(int FacilNo, DateTime startDate, DateTime endDate);

        Task<AllEvent> GetByEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo, AllEvent? allEvent);

        Task<IEnumerable<AllEvent>> FindEvents(Expression<Func<AllEvent, bool>> predicate);

        // Task<IEnumerable<AllEvent>> GetOutstandingEvents(int FacilNo, int LogTypeNo);

        // Task<IEnumerable<AllEvent>> GetAllEventsByFacilAndLogType(int FacilNo, int LogTypeNo, DateTime startDate, DateTime endDate);

        #endregion

        #region Commands

        //Task<bool> AddEvent(AllEvent allEvent);

        // Soft Delete
        //Task<bool> DeleteEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

        // Mark the original entiry as revised or modified, and create a new entity with new revision number
        //Task<bool> Upsert(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo, AllEvent allEvent);

        #endregion

        

    }
}
