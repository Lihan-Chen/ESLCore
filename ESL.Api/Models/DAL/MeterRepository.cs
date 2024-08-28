using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ESL.Api.Models.DAL
{
    public class MeterRepository : IMeterRepository
    {
        private ApplicationDbContext _context;

        private ILogger<MeterRepository> _logger;
        
        public MeterRepository(
            ApplicationDbContext context,
            ILogger<MeterRepository> logger
            )  // : base(context, logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<List<Meter>?> GetList(int facilNo) => await _context.Meters.Where(m => m.FacilNo == facilNo && m.Disable == null).OrderByDescending(o => o.UpdateDate).AsNoTracking().ToListAsync();

        //.Take(10).Skip(1)
        public async Task<Meter?> GetItem(int facilNo, string meterID) => await _context.Meters.Where(m => m.FacilNo == facilNo && m.MeterID == meterID).FirstOrDefaultAsync();

        public async Task<string> Update(int facilNo, string meterID, Meter meter, string forceUpdate = "D")
        {
            {
                if (facilNo != meter.FacilNo && meterID != meter.MeterID)
                {
                    return "Bad Request"; // BadRequest();
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
                        return null; // NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return meterID; // NoContent();
            }
        }

        public async Task<string> Delete(int facilNo, string meterID)
        {
            var meter = await _context.Meters.FindAsync(facilNo, meterID);
            if (meter == null)
            {
                return "Not Found"; //NotFound();
            }

            _context.Meters.Remove(meter);
            await _context.SaveChangesAsync();

            return meterID; //  NoContent();
        }

        private bool MeterExists(int facilNo, string meterID)
        {
            return _context.Meters.Any(e => e.FacilNo == facilNo && e.MeterID == meterID);
        }


        //public Task<string> GetFullName(Guid id)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
