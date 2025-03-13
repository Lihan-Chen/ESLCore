using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.IRepositories;
using ESL.Api.Models.ViewModels;
//using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ESL.Api.Models.DAL
{
    public class AllEventRepository : IAllEventRepository
    {
        private ApplicationDbContext _context;

        private ILogger<AllEventRepository> _logger;

        public AllEventRepository(
            ApplicationDbContext context,
            ILogger<AllEventRepository> logger
            ) // : base(context, logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        public IQueryable<Details> GetDetailsListQuery(int facilNo)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ViewAlleventsCurrent> GetItemQuery(int? facilNo, int? logTypeNo, string eventID, int? eventID_RevNo)
        {
            //string _logTypeSql = logTypeNo == null ? "" : $"AND A.LOGTYPENO = '{logTypeNo}.ToString()' ";

            //string _sql = $"SELECT A.FACILNO, B.FACILNAME, B.FACILABBR, A.LOGTYPENO, C.LOGTYPENAME, A.EVENTID, A.EVENTID_REVNO, " +
            //              $"A.EVENTDATE, A.EVENTTIME, A.SUBJECT, A.DETAILS, A.MODIFYFLAG, A.NOTES, A.OPERATORTYPE, " +
            //              $"A.UPDATEDBY, A.UPDATEDATE, A.CLEARANCEID, A.SCANDOCSNO " +
            //              $"FROM ESL.VIEW_ALLEVENTS_CURRENT A, " +
            //              $"ESL.ESL_FACILITIES B, " +
            //              $"ESL.ESL_LOGTYPES C " +
            //              $"WHERE A.FACILNO = '{facilNo}.ToString()' AND " +
            //              _logTypeSql +
            //              $"A.EVENTID = '{eventID}' AND " +
            //              $"A.EVENTID_REVNO = '{eventID_RevNo}.ToString()' AND" +
            //              $"A.FACILNO = B.FACILNO AND A.LOGTYPENO = C.LOGTYPENO;";

            //var query = _context.AllEvents.FromSqlRaw(_sql).AsNoTracking();

            //var query = from a in _context.VIEW_ALLEVENTS_CURRENT
            //            join b in _context.ESL_FACILITIES on a.FACILNO equals b.FACILNO
            //            join c in _context.ESL_LOGTYPES on a.LOGTYPENO equals c.LOGTYPENO
            //            where a.FACILNO == facilNo.ToString() &&
            //                  a.EVENTID == eventID &&
            //                  a.EVENTID_REVNO == eventID_RevNo
            //            select new
            //            {
            //                a.FACILNO,
            //                b.FACILNAME = Facility.,
            //                b.FACILABBR,
            //                a.LOGTYPENO,
            //                c.LOGTYPENAME,
            //                a.EVENTID,
            //                a.EVENTID_REVNO,
            //                a.EVENTDATE,
            //                a.EVENTTIME,
            //                a.SUBJECT,
            //                a.DETAILS,
            //                a.MODIFYFLAG,
            //                a.NOTES,
            //                a.OPERATORTYPE,
            //                a.UPDATEDBY,
            //                a.UPDATEDATE,
            //                a.CLEARANCEID,
            //                a.SCANDOCSNO
            //            };

            //return query.AsNoTracking();

            // implicit join for query performance improvement
           return _context.ViewAlleventsCurrents
                        .AsNoTracking()
                        .TagWith("GetItemQuery")
                        .Where(a => a.FacilNo == facilNo &&
                               a.LogTypeNo == logTypeNo &&
                               a.EventID == eventID &&
                               a.EventID_RevNo == eventID_RevNo);

            // join b in _context.ESL_FACILITIES on a.FACILNO equals b.FACILNO
            // join c in _context.ESL_LOGTYPES on a.LOGTYPENO equals c.LOGTYPENO                       
            //.Select(a => new AllEvent
            //{
            //    FacilNo = a.FACILNO,
            //    FacilName = a.Facility.FacilName,
            //    FacilAbbr = a.Facility.FacilAbbr,
            //    LogTypeNo = a.LogTypeNo,
            //    LogTypeName = a.LogType.LogTypeName,
            //    EventID = a.EVENTID,
            //    EventID_RevNo = a.EVENTID_REVNO,
            //    a.EVENTDATE,
            //    a.EVENTTIME,
            //    a.SUBJECT,
            //    a.DETAILS,
            //    a.MODIFYFLAG,
            //    a.NOTES,
            //    a.OPERATORTYPE,
            //    a.UPDATEDBY,
            //    a.UPDATEDATE,
            //    a.CLEARANCEID,
            //    a.SCANDOCSNO
            //};
        }

        public IQueryable<ViewAlleventsCurrent> GetListQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate, string strOperatorType)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AllEvent> GetReportQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Search_RelatedToVM> GetSearch_RelatedToListQuery(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Subject> GetSubjectListQuery(int facilNo)
        {
            throw new NotImplementedException();
        }

        IQueryable<BusinessEntities.Details> IAllEventRepository.GetDetailsListQuery(int facilNo)
        {
            throw new NotImplementedException();
        }

        IQueryable<BusinessEntities.ViewAlleventsCurrent> IAllEventRepository.GetItemQuery(int? facilNo, int? logTypeNo, string eventID, int? eventID_RevNo)
        {
            throw new NotImplementedException();
        }

        IQueryable<BusinessEntities.ViewAlleventsCurrent> IAllEventRepository.GetListQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate, string strOperatorType)
        {
            throw new NotImplementedException();
        }

        IQueryable<BusinessEntities.AllEvent> IAllEventRepository.GetReportQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate)
        {
            throw new NotImplementedException();
        }

        IQueryable<BusinessEntities.Subject> IAllEventRepository.GetSubjectListQuery(int facilNo)
        {
            throw new NotImplementedException();
        }
    }
}
