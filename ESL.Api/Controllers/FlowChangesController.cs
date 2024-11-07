using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.DAL;
using Mono.TextTemplating;
using System.Globalization;

namespace ESL.Api.Controllers
{
    //[Route("api/[controller]")]
    public class FlowChangesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlowChangesController(ApplicationDbContext context)
        {
            _context = context;
        }

        int _facilNo;
        string _facilName;
        const int _logTypeNo = 5;
        const string _logTypeName = "Flow Change";
        string _startDate;
        string _endDate;
        DateTime? initialStartDate;
        //int _daysOffSet = -1;
        string _operatorType = String.Empty;
        bool _opType = true;
        bool showAlert = false;
        string Alert;

        int _yr = System.DateTime.Now.Year - 2000;
        int _nextSeqNo;
        int _maxRevNo;
        int _shiftNo;
        int _updatedBy;

        string _oldUnit = string.Empty;

        public int _pageSize = 40;
        public int _daysOffset = -1;

        // GET: FlowChanges
        [HttpGet("FlowChange/")]
        public async Task<ActionResult<List<FlowChange>>> Index(int facilNo, DateTime? startDate, DateTime? endDate, string searchString, string alert, int? page, bool operatorType = false) // , string active, string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (!String.IsNullOrEmpty(alert))
            {
                ViewBag.ShowAlert = true;
                ViewBag.Alert = alert;
            }

            _facilNo = facilNo;

            
            // Only for MVC, not applicable for api
            //if (_facilNo == 0)
            //{
            //    showAlert = true;
            //    return RedirectToAction("Index", "Home", new { ReturnUrl = this.Url, ShowAlert = showAlert });
            //}

            //Session["FacilNo"] = _facilNo;

            _operatorType = operatorType == true ? "Primary" : "Secondary";

            string _sqlOperatorType = operatorType == true ? $" A.OPERATORTYPE = '{_operatorType}' AND " : string.Empty;

            string _sqlSearch = searchString != null ? $" UPPER(A.METERID || B.SUBJECT || B.DETAILS) LIKE  UPPER('%{searchString}%') AND " : string.Empty;

            // _shiftNo = DateTime.Now

            DateTime _enDt = endDate ?? DateTime.Now.Date.AddDays(1);

            DateTime _stDt = startDate ?? _enDt.AddDays(_daysOffset).AddTicks(-1);

            string _enDtStr = _enDt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            string _stDtStr = _stDt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            // searchString = !String.IsNullOrEmpty(logFilterPartial.CurrentFilter) ? logFilterPartial.CurrentFilter : searchString;

            // _opType = _operatorType.HasValue ? true : logFilterPartial.OperatorType;

            // When sql statement ends with a ";", linq statement may cause an ORA error: missing right parenthesis.
            string sql = $"SELECT A.FACILNO, B.FACILNAME, A.LOGTYPENO, B.LOGTYPENAME, A.EVENTID, A.EVENTID_REVNO, " +
                                    $" A.OPERATORID, A.CREATEDBY, A.CREATEDDATE, A.REQUESTEDBY, A.REQUESTEDTO, A.REQUESTEDDATE, A.REQUESTEDTIME, " +
                                    $" A.EVENTDATE, A.EVENTTIME, A.OFFTIME, A.METERID, A.CHANGEBY, A.NEWVALUE, A.UNIT, A.OLDVALUE, A.OLDUNIT, A.CHANGEBYUNIT, A.ACCEPTED, " +
                                    $" A.MODIFYFLAG, A.MODIFIEDBY, A.MODIFIEDDATE, A.NOTES, A.NOTIFIEDFACIL, A.NOTIFIEDPERSON, A.SHIFTNO, A.YR, A.SEQNO, " +
                                    $" A.UPDATEDBY, A.UPDATEDATE, A.WORKORDERS, A.RELATEDTO, A.OPERATORTYPE, B.SUBJECT EVENTSUBJECT, B.DETAILS EVENTDETAILS, B.SCANDOCSNO " +
                                    $" FROM ESL.ESL_FLOWCHANGES A, " +
                                    $" ESL.VIEW_FLOWCHANGE_PRESCHED B " +
                                    $" WHERE A.FACILNO =  {facilNo} AND " +
                                    $" A.LOGTYPENO = {_logTypeNo} AND " +
                                    //$" A.EVENTDATE BETWEEN {_stDt} AND {_enDt} AND \r\n " +
                                    //$" A.EVENTDATE <= :enDt AND --_strEndDate To_Date('07312013', 'MMDDRRRR')\r\n " +
                                    $" A.EVENTDATE BETWEEN To_Date('{_stDtStr}', 'MM/dd/rrrr') AND To_Date('{_enDtStr}', 'MM/dd/rrrr') AND " +
                                    $" {_sqlOperatorType} " +
                                    $" {_sqlSearch}" +
                                    $" A.EVENTID = B.EVENTID AND A.EVENTID_REVNO = B.EVENTID_REVNO AND " +
                                    $" A.FACILNO = B.FACILNO AND A.LOGTYPENO = B.LOGTYPENO " +
                                    $" ORDER BY FACILNO, LOGTYPENO ASC, " +
                                    $" TO_CHAR(B.EVENTDATE, 'rrrrmmdd')||B.EVENTTIME DESC, A.UPDATEDATE DESC"; // ; Additional ending ";" causes Oracle error!

            //Execute stored procedure ESL.ESL_FLOWCHANGES_OUTSTANDING with parameters and RefCur (BECAUSE VIEW is the pain point!)
            //var outstandingFlowChanges = _context.Database.ExecuteSqlAsync(sql, {_facilNo}, {_logTypeNo}, {_stDate}, {_enDt}).AsQueryable();            //var currentFlowChanges = _context.FlowChanges.Where(a => a.FacilNo == facilNo && a.LogTypeNo == _logTypeNo && a.EventDate >= startDate && a.EventDate <= endDate && a.OperatorType == _operatorType).AsQueryable();

            //var outstandingFlowChanges =  _context?.FlowChanges.FromSql($"sql, { _facilNo}, { _logTypeNo}, { _stDt}, { _enDt}");

            var queryResult = await _context.FlowChanges.FromSqlRaw(sql)
                                    .OrderByDescending(o => o.EventDate)
                                    .ThenByDescending(o => o.EventTime)
                                    .AsNoTracking()
                                    .Take(_pageSize)
                                    .Skip(0)
                                    .ToListAsync();

            //var query = _context.FlowChanges.FromSqlRaw(sql); //.OrderByDescending(o => o.EventDate).ThenByDescending(o => o.EventTime).AsNoTracking().Take(_pageSize).Skip(0).ToListAsync();

            // this following linq query causes a missing right parenthsis in Oracle.  Possibly a bug.
            //if (operatorType == true)
            //    query = query.Where(o => o.OperatorType.Equals($"{_operatorType})"));

            //if (searchString != null)
            //    query = query.Where(e => EF.Functions.Like(e.EventSubject.ToUpperInvariant(), searchString.ToUpper())
            //                                                        || EF.Functions.Like(e.EventHighlight.ToUpper(), searchString.ToUpper())
            //                                                        || EF.Functions.Like(e.EventHeader.ToUpper(), searchString.ToUpper())
            //                                                      );
            //|| EF.Functions.Like(e.EventDetails.ToUpper(), searchString.ToUpper())
            //|| EF.Functions.Like(e.EventTrail.ToUpper(), searchString.ToUpper());

            //var outstandingFlowchanges = query.OrderByDescending(o => o.EventDate).ThenByDescending(o => o.EventTime).Take(_pageSize).Skip(0).ToList();

            return queryResult; // outstandingFlowchanges; 
        }

        // GET: FlowChanges/Details/5
        [HttpGet("FlowChange_Details/{facilNo}/{eventID}/{eventID_RevNo}")]
        public async Task<ActionResult<FlowChange>> Details(int? facilNo, string eventID, int? eventID_RevNo)
        {
            int logTypeNo = _logTypeNo;
            
            if (facilNo == null ||  eventID == null || eventID_RevNo == null) // logTypeNo == null ||
            {
                return BadRequest();
            }

            var flowChange = await _context.FlowChanges
                .FirstOrDefaultAsync(m => m.FacilNo == facilNo && m.LogTypeNo == logTypeNo && m.EventID == eventID && m.EventID_RevNo == eventID_RevNo);

            if (flowChange == null)
            {
                return NotFound();
            }

            return flowChange;
        }

        //// GET: FlowChanges/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: FlowChanges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacilNo,LogTypeNo,EventID,EventID_RevNo,OperatorID,CreatedBy,CreatedDate,RequestedBy,RequestedTo,RequestedDate,RequestedTime,EventDate,EventTime,OffTime,MeterID,ChangeBy,NewValue,Unit,OldValue,OldUnit,ChangeByUnit,Accepted,ModifyFlag,ModifiedBy,ModifiedDate,Notes,NotifiedFacil,NotifiedPerson,ShiftNo,Yr,SeqNo,UpdatedBy,UpdateDate,WorkOrders,RelatedTo,OperatorType")] FlowChange flowChange)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flowChange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flowChange);
        }

        // GET: FlowChanges/Edit/5
        public async Task<IActionResult> Edit(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            if (facilNo == null  || eventID == null || eventID_RevNo == null)
            {
                return NotFound();
            }

            var flowChange = await _context.FlowChanges.FindAsync(facilNo, logTypeNo, eventID, eventID_RevNo);
            if (flowChange == null)
            {
                return NotFound();
            }
            return View(flowChange);
        }

        // POST: FlowChanges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int facilNo, [Bind("FacilNo,LogTypeNo,EventID,EventID_RevNo,OperatorID,CreatedBy,CreatedDate,RequestedBy,RequestedTo,RequestedDate,RequestedTime,EventDate,EventTime,OffTime,MeterID,ChangeBy,NewValue,Unit,OldValue,OldUnit,ChangeByUnit,Accepted,ModifyFlag,ModifiedBy,ModifiedDate,Notes,NotifiedFacil,NotifiedPerson,ShiftNo,Yr,SeqNo,UpdatedBy,UpdateDate,WorkOrders,RelatedTo,OperatorType")] FlowChange flowChange)
        {
            if (facilNo != flowChange.FacilNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flowChange);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowChangeExists(flowChange.FacilNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flowChange);
        }

        // GET: FlowChanges/Delete/5
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowChange = await _context.FlowChanges
                .FirstOrDefaultAsync(m => m.FacilNo == id);
            if (flowChange == null)
            {
                return NotFound();
            }

            return View(flowChange);
        }

        //// POST: FlowChanges/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        //{
        //    var flowChange = await _context.FlowChanges.FindAsync(facilNo, logTypeNo, eventID, eventID_RevNo);
        //    if (flowChange != null)
        //    {
        //        _context.FlowChanges.Remove(flowChange);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        
        public int GetMaxSeqNo(int facilNo, int yr)
        {
            //int _maxSeqNo = 0;
            int _logTypeNo = 5;

            //string _sql = $"SELECT MAX(SEQNO) MaxSeqNo FROM ESL.ESL_FlowChanges WHERE FACILNO = {facilNo} AND LOGTYPENO = {_logTypeNo} AND yr = {yr}";

            //int maxSeqNo = _context.Database.ExecuteSqlRaw(_sql);

            return _context.FlowChanges.Where(f => f.FacilNo == facilNo && f.LogTypeNo == _logTypeNo && f.Yr == yr.ToString()).Max(f => f.SeqNo);
        }
        
        public int GetMaxRevNo(int facilNo, string eventID)
        {
            return _context.FlowChanges.Where(f => f.FacilNo == facilNo && f.EventID == eventID).Max(f => f.EventID_RevNo);
        }
        
        private bool FlowChangeExists(int id)
        {
            return _context.FlowChanges.Any(e => e.FacilNo == id);
        }

    }
}
