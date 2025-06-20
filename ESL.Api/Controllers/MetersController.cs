﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.DAL;
using ESL.Api.Models.IRepositories;

namespace ESL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMeterRepository _meterRepository;

        public MetersController(ApplicationDbContext context, IMeterRepository meterRepository)
        {
            _context = context;
            _meterRepository = meterRepository;
        }

        //private int _facilNo = sessionFacilNo; //Should be from ESLControllerBase.Session["FacilNo"]

        // GET: api/Meters
        [HttpGet("MetersPerFacility")]// 
        public async Task<ActionResult<IEnumerable<Meter>>> GetMetersList(int facilNo = 0) //
        {
            return await _meterRepository.GetList(facilNo).ToListAsync(); //.Take(10).Skip(1)
        }


        // GET: api/Meters
        [HttpGet("GetMetersByFacility/{facilNo}")]// 
        public async Task<ActionResult<IEnumerable<Meter>>> GetMetersByFacilNo(int facilNo) //
        {
            return await _meterRepository.GetList(facilNo).ToListAsync(); //.Take(10).Skip(1) //.Take(10).Skip(1)
        }

        // GET: api/Meters/5
        [HttpGet("MeterInfo/{facilNo}/{meterID}")]
        public async Task<ActionResult<Meter>> GetMeter(int facilNo, string meterID)
        {
            //string _sql = $"SELECT * FROM ESL.ESL_METERS WHERE FACILNO = {facilNo} AND METERID = {meterID}";

            var meter = await _meterRepository.GetItem(facilNo, meterID).FirstOrDefaultAsync();

            if (meter == null)
            {
                return NotFound();
            }

            return meter;
        }

        // PUT: api/Meters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // ESL.ESL_UPDATE_METERS_PROC
        [HttpPut("UpdateMeter")]
        public async Task<IActionResult> Update([FromBody]Meter meter, string ForceUpdate)
        {
            if (!MeterExists(meter.FacilNo, meter.MeterID))
            {
                await PostMeter(meter);
                // return BadRequest();
            }

            if (ForceUpdate == "Y")
            {
                _context.Entry(meter).State = EntityState.Modified;
            }
            else if(ForceUpdate == "D")
            {
                _context.Entry(meter).State = EntityState.Deleted;
                // or call DeleterMeter(meter.FacilNo, meter.MeterID);
            }            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeterExists(meter.FacilNo, meter.MeterID))
                {
                    await PostMeter(meter);
                    // return NotFound();
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
        [HttpPost("AddMeter")]
        public async Task<ActionResult<Meter>> PostMeter([FromBody]Meter meter)
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
        [HttpDelete("Delete/{facilNo}/{meterID}")]
        public async Task<IActionResult> DeleteMeter(int facilNo, string meterID)
        {
            if (facilNo == 0 || string.IsNullOrEmpty(meterID))
            {
                return BadRequest();
            }

            var meter = await _context.Meters.FindAsync(facilNo, meterID);

            if (meter == null)
            {
                return NotFound();
            }

            //_context.Meters.Remove(meter);

            // Soft Delete
            meter.Disable = "Y";
            _context.Entry(meter).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeterExists(int facilNo, string meterID)
        {
            return _context.Meters.Any(e => e.FacilNo == facilNo && e.MeterID == meterID);
        }

        private bool MeterExists(Meter meter)
        {
            return _context.Meters.Any(e => e.FacilNo == meter.FacilNo && e.MeterID.ToUpper() == meter.MeterID.ToUpper());
        }
    }
}
