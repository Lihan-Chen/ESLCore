using ESL.Core.Models.BusinessEntities;
using System.Linq.Expressions;

namespace ESL.Core.IRepositories
{
    public interface IAllEventRepository // : IEventRepository<AllEvent>
    {

        public IQueryable<AllEvent> GetDefaultAllEventsByFacil(int FacilNo, DateTime startDate, DateTime endDate);

        public IQueryable<AllEvent> GetByEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

        public IQueryable<AllEvent> FindEvents(Expression<Func<AllEvent, bool>> predicate);
        
        // _sql = "ESL.ESL_RPT_ALLEVENTS_PROC"; 
        public IQueryable<AllEvent> GetReportQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate);

        public IQueryable<AllEventCurrent> GetAllEventsCurrentQuery(int FacilNo);

        // _sql = "ESL.ESL_ALLEVENTS_ACTIVE_PROC";
        public IQueryable<AllEventCurrent> GetListQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate, string strSearch, string strOperatorType);

        public IQueryable<AllEventCurrent> GetItemQuery(int? facilNo, int? logTypeNo, string eventID, int? eventID_RevNo);
        
        // _sql = "ESL.ESL_ALLEVENTS_RELATEDTO_PROC";
        public IQueryable<AllEventRelatedTo> GetSearch_RelatedToListQuery(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues);

        // _sql = "ESL.ESL_DETAILSLIST_PROC";
        public IQueryable<Details> GetDetailsListQuery(int facilNo);

        // string _sql = "ESL.ESL_SUBJECTLIST_PROC";
        public IQueryable<Subject> GetSubjectListQuery(int facilNo);

        //Task<bool> AddEvent(AllEvent allEvent);

        // Soft Delete
        //Task<bool> DeleteEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

        // Mark the original entiry as revised or modified, and create a new entity with new revision number
        //Task<bool> Upsert(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo, AllEvent allEvent);
    }
}
