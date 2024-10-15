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
        public const String shiftEndText = "17:59:00";
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

            _operatorType = operatorType == true ? "Primary" : "Secondary";

            // _shiftNo = DateTime.Now

            DateTime _enDt = endDate ?? DateTime.Now.Date.AddDays(1);

            DateTime _stDt = startDate ?? _enDt.AddDays(_daysOffset);

            // searchString = !String.IsNullOrEmpty(logFilterPartial.CurrentFilter) ? logFilterPartial.CurrentFilter : searchString;

            // _opType = _operatorType.HasValue ? true : logFilterPartial.OperatorType;

            // To Do: conditional Where's are needed to accurately filter all events
            var viewCurrentAllevents = _context.ViewAlleventsCurrents.Where(a => a.FacilNo == facilNo  && a.EventDate >= _stDt && a.EventDate <= _enDt && a.OperatorType == _operatorType).AsQueryable(); //.AsNoTracking().ToListAsync();

            if (logTypeNo != null)

                viewCurrentAllevents = viewCurrentAllevents.Where(e => e.LogTypeNo == logTypeNo).AsQueryable();

            if (searchString != null)
                viewCurrentAllevents = viewCurrentAllevents.Where(e => EF.Functions.Like(e.EventID.ToUpper(), searchString.ToUpper())
                                      || EF.Functions.Like(e.Subject.ToUpper(), searchString.ToUpper())
                                      || EF.Functions.Like(e.Details.ToUpper(), searchString.ToUpper()));

            var CurrentAllevents = await viewCurrentAllevents.OrderByDescending(o => o.EventDate).ThenByDescending(o => o.EventTime).Take(_pageSize).Skip(0).ToListAsync();


            if (CurrentAllevents == null)
            {
                return NotFound();
            }

            return CurrentAllevents;
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

        
        //Not Needed
        //// POST: api/ViewAlleventsCurrents
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ViewAlleventsCurrent>> PostAllevents(ViewAlleventsCurrent viewAlleventsCurrent)
        //{
        //    _context.ViewAlleventsCurrents.Add(viewAlleventsCurrent);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ViewAlleventsCurrentExists(viewAlleventsCurrent.FacilNo, viewAlleventsCurrent.LogTypeNo, viewAlleventsCurrent.EventID, viewAlleventsCurrent.EventID_RevNo))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetViewAlleventsCurrent", new { facilNo = viewAlleventsCurrent.FacilNo, logTypeNo = viewAlleventsCurrent.LogTypeNo, eventID = viewAlleventsCurrent.EventID, eventID_RevNo = viewAlleventsCurrent.EventID_RevNo }, viewAlleventsCurrent);
        //}

        
        // Not Needed
        //// DELETE: api/ViewAlleventsCurrents/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteViewAlleventsCurrent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        //{
        //    var viewAlleventsCurrent = await _context.ViewAlleventsCurrents.Where(a => a.FacilNo == facilNo && a.LogTypeNo == logTypeNo && a.EventID == eventID && a.EventID_RevNo == eventID_RevNo).FirstOrDefaultAsync();
        //    if (viewAlleventsCurrent == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ViewAlleventsCurrents.Remove(viewAlleventsCurrent);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ViewAlleventsCurrentExists(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            return _context.ViewAlleventsCurrents.Any(e => e.FacilNo == facilNo && e.LogTypeNo == logTypeNo && e.EventID == eventID && e.EventID_RevNo == eventID_RevNo);
        }
    }
}
