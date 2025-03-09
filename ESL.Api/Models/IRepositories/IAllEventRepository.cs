using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.ViewModels;

namespace ESL.Api.Models.IRepositories
{
    public interface IAllEventRepository
    {// _sql = "ESL.ESL_ALLEVENTS_ACTIVE_PROC";
        public IQueryable<ViewAlleventsCurrent> GetListQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate, string strOperatorType);

        public IQueryable<ViewAlleventsCurrent> GetItemQuery(int? facilNo, int? logTypeNo, string eventID, int? eventID_RevNo);

        // _sql = "ESL.ESL_RPT_ALLEVENTS_PROC"; 
        public IQueryable<AllEvent> GetReportQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate);

        // _sql = "ESL.ESL_ALLEVENTS_RELATEDTO_PROC"; 
        public IQueryable<Search_RelatedToVM> GetSearch_RelatedToListQuery(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues);

        // _sql = "ESL.ESL_DETAILSLIST_PROC";
        public IQueryable<Details> GetDetailsListQuery(int facilNo);

        // string _sql = "ESL.ESL_SUBJECTLIST_PROC";
        public IQueryable<Subject> GetSubjectListQuery(int facilNo);
    }
}
