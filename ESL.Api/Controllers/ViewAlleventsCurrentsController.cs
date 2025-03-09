using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.DAL;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ESL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewAlleventsCurrentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViewAlleventsCurrentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ViewAlleventsCurrents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewAlleventsCurrent>>> GetAll()
        {
            return await _context.ViewAlleventsCurrents.ToListAsync();
        }

        // private variables
        
        // Primary Key
        int _facilNo;
        int _logTypeNo = 5;
        string _eventID = null!;
        int _eventID_RevNo;

        string _facilName;
        string _logTypeName;
        
        string _startDate;
        string _endDate;
        DateTime? initialStartDate;

        string _shiftNo = null!;
        string _operatorType = null!;
        bool _opType = true;

        public const String shiftStartText = "06:00:00";  // for Day shift
        public const String shiftEndText = "17:59:59";
        public DateTime now = DateTime.Now;
        public DateTime tomorrow = DateTime.Now.AddDays(+1);

        public int _pageSize = 40;
        public int _daysOffset = -1;


        // GET: api/ViewAlleventsCurrents/5
        [HttpGet("AllEventsByFacility/{facilNo}")]
        //[Route("AllEvents")]
        public async Task<ActionResult<List<ViewAlleventsCurrent>>> GetAlleventList(int facilNo, int? logTypeNo, DateTime? startDate, DateTime? endDate, string? searchString, string? alert, int? page, bool? operatorType = false) // , string active, string sortOrder, string currentFilter, string searchString, int? page)
        {
            _facilNo = facilNo;

            _operatorType = (bool)operatorType ? "Primary" : "Secondary";

            // _shiftNo = DateTime.Now

            DateTime _enDt = endDate ?? DateTime.Now.Date.AddDays(1);

            DateTime _stDt = startDate ?? _enDt.AddDays(_daysOffset).AddTicks(-1);

            // searchString = !String.IsNullOrEmpty(logFilterPartial.CurrentFilter) ? logFilterPartial.CurrentFilter : searchString;

            // _opType = _operatorType.HasValue ? true : logFilterPartial.OperatorType;

            // To Do: conditional Where's are needed to accurately filter all events
            var query = _context.ViewAlleventsCurrents.AsNoTracking().TagWith("ESL.ESL_ALLEVENTS_ACTIVE_PROC").Where(a => a.FacilNo == facilNo && a.EventDate >= _stDt && a.EventDate <= _enDt && a.OperatorType == _operatorType);

            if (logTypeNo != null)

                query = query.Where(e => e.LogTypeNo == logTypeNo);

            if (searchString != null)
            { 
                query = query.Where(e => EF.Functions.Like(e.EventID.ToUpper(), searchString.ToUpper())
                                      || EF.Functions.Like(e.Subject!.ToUpper(), searchString.ToUpper())
                                      || EF.Functions.Like(e.Details!.ToUpper(), searchString.ToUpper()));
            }

            var CurrentAllevents = await query.OrderByDescending(o => o.EventDate).ThenByDescending(o => o.EventTime).Take(_pageSize).Skip(0).ToListAsync();


            if (CurrentAllevents == null)
            {
                return NotFound(alert);
            }

            return CurrentAllevents;
        }

        // not used, revisit if necessary (EF Core version is better)
        [HttpGet("AllEventsByFacilityProcedure/{facilNo}")]
        public async Task<ActionResult<IEnumerable<ViewAlleventsCurrent>>> GetAlleventListProcedure(int facilNo, int? logTypeNo, DateTime? startDate, DateTime? endDate, string? searchString, string? alert, int? page, bool? operatorType = false) // , string active, string sortOrder, string currentFilter, string searchString)
        {
            _facilNo = facilNo;

            _operatorType = operatorType == true ? "Primary" : "Secondary";

            int _page = 0;

            // _shiftNo = DateTime.Now

            DateTime _enDt = endDate ?? DateTime.Now.Date.AddDays(1);

            DateTime _stDt = startDate ?? _enDt.AddDays(_daysOffset).AddTicks(-1);

            string _stDtStr = _stDt.ToString("yyyyMMdd");

            string _enDtStr = _enDt.ToString("yyyyMMdd");

            // searchString = !String.IsNullOrEmpty(logFilterPartial.CurrentFilter) ? logFilterPartial.CurrentFilter : searchString;

            // _opType = _operatorType.HasValue ? true : logFilterPartial.OperatorType;

            // To Do: conditional Where's are needed to accurately filter all events

            var p_allEvents = new OracleParameter("allEventActiveCur", OracleDbType.RefCursor, ParameterDirection.Output);

            var p_facilNo = new OracleParameter("@inFacilNo", OracleDbType.Int32, ParameterDirection.Input);
            var p_logTypeNo = new OracleParameter("@inLogTypeNo", OracleDbType.Int32, ParameterDirection.Input);
            var p_startDate = new OracleParameter("@inStartDate", OracleDbType.Varchar2, ParameterDirection.Input);
            var p_endDate = new OracleParameter("@inEndDate", OracleDbType.Varchar2, ParameterDirection.Input);
            // var p_searchString = new OracleParameter("@inSearchString", OracleDbType.Varchar2, ParameterDirection.Input);
            var p_operatorType = new OracleParameter("@inOperatorType", OracleDbType.Varchar2, ParameterDirection.Input);

            return await _context.ViewAlleventsCurrents.FromSqlRaw("ESL.ESL_ALLEVENTS_ACTIVE_PROC @inFacilNo, @inLogTypeNo, @inStartDate, @inEndDate, @_operatorType, @allEventActiveCur OUT", new object[] { p_facilNo, p_logTypeNo, p_startDate, p_endDate, p_operatorType, p_allEvents }).ToListAsync();
            // .Take(_pageSize).Skip(_page).ToListAsync();

            //var result = await _context.ViewAlleventsCurrents.FromSqlRaw("BEGIN ESL.ESL_ALLEVENTS_ACTIVE_PROC(inFacilNo, inLogTypeNo, _stDeStr, _enDtStr, _operatorType, allEventActiveCur); END;", new object[]

            //return result;

            //var roleParameter = new SqlParameter()
            //{
            //    ParameterName = "Role",
            //    SqlDbType = System.Data.SqlDbType.VarChar,
            //    Direction = System.Data.ParameterDirection.Output
            //};
            //SELECT ROLE FROM ESL.ESL_ALLSCADAUSERS_ROLE WHERE UPPER(USERID) = UPPER('UserID') AND FACILNO = facilNo//new SqlParameter("@inUserID", userID),
            //string _role = _context.Database.FromSql("ESL_GETEMPLOYEEROLEBYFACIL @inUserID, @inFacilNo, @Role OUTPUT", userID, facilNo, roleParameter);
            //new SqlParameter("@inUserID", userID),
            //new SqlParameter("@inFacilNo", facilNo),
            //roleParameter);
        }

        [HttpGet("GetEvent/{facilNo}/{logTypeNo}/{eventID}/{eventID_RevNo}")] 
        public async Task<ViewAlleventsCurrent> GetItem(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            return await _context.ViewAlleventsCurrents.FirstOrDefaultAsync(a => a.FacilNo == facilNo && a.LogTypeNo == logTypeNo && a.EventID == eventID && a.EventID_RevNo == eventID_RevNo);
        }

        // PUT: api/ViewAlleventsCurrents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{facilNo}/{logTypeNo}/{eventID}/{eventID_RevNo}")]
        public async Task<IActionResult> PutAllevents(int facilNo, int logTypeNo, string eventID, int eventID_RevNo, ViewAlleventsCurrent viewAlleventsCurrent)
        {
            if (facilNo != viewAlleventsCurrent.FacilNo || logTypeNo != viewAlleventsCurrent.LogTypeNo || eventID != viewAlleventsCurrent.EventID || eventID_RevNo != viewAlleventsCurrent.EventID_RevNo)
            {
                return BadRequest();
            }

            _context.Entry(viewAlleventsCurrent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewAlleventsCurrentExists(viewAlleventsCurrent.FacilNo, viewAlleventsCurrent.LogTypeNo, viewAlleventsCurrent.EventID, viewAlleventsCurrent.EventID_RevNo))
                {   
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        private bool ViewAlleventsCurrentExists(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            return _context.ViewAlleventsCurrents.Any(e => e.FacilNo == facilNo && e.LogTypeNo == logTypeNo && e.EventID == eventID && e.EventID_RevNo == eventID_RevNo);
        }
    }
}
