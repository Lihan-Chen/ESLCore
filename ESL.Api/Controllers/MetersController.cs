using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.DAL;

namespace ESL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MetersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //private int _facilNo = sessionFacilNo; //Should be from ESLControllerBase.Session["FacilNo"]

        // GET: api/Meters
        [HttpGet("{facilNo}")]// 
        public async Task<ActionResult<IEnumerable<Meter>>> GetMetersByFacilNo(int facilNo) //
        {
            return await _context.Meters.Where(m => m.FacilNo == facilNo && m.Disable == null).OrderByDescending(o => o.UpdateDate).AsNoTracking().ToListAsync(); //.Take(10).Skip(1)
        }

        // GET: api/Meters/5
        [HttpGet("{facilNo}/{meterID}")]
        public async Task<ActionResult<Meter>> GetMeter(int facilNo, string meterID)
        {
            var meter = await _context.Meters.Where(m => m.FacilNo == facilNo && m.MeterID == meterID).FirstOrDefaultAsync();

            if (meter == null)
            {
                return NotFound();
            }

            return meter;
        }

        // PUT: api/Meters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{facilNo}/{meterID}")]
        public async Task<IActionResult> PutMeter(int facilNo, string meterID, Meter meter)
        {
            if (facilNo != meter.FacilNo && meterID != meter.MeterID)
            {
                return BadRequest();
            }

            _context.Entry(meter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeterExists(facilNo, meterID))
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

        // POST: api/Meters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meter>> PostMeter(Meter meter)
        {
            _context.Meters.Add(meter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MeterExists(meter.FacilNo, meter.MeterID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMeter", new { facilNo = meter.FacilNo, meterID = meter.MeterID }, meter);
        }

        // DELETE: api/Meters/{facilNo}/{meterID}
        [HttpDelete("{facilNo}/{meterID}")]
        public async Task<IActionResult> DeleteMeter(int facilNo, string meterID)
        {
            var meter = await _context.Meters.FindAsync(facilNo, meterID);
            if (meter == null)
            {
                return NotFound();
            }

            _context.Meters.Remove(meter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeterExists(int facilNo, string meterID)
        {
            return _context.Meters.Any(e => e.FacilNo == facilNo && e.MeterID == meterID);
        }
    }
}
