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
            ) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IQueryable<Meter> GetList(int facilNo = 0)
        {
            var query = _context.Meters.AsNoTracking().Where(m => m.Disable == null);
        
            if (facilNo != 0)
            {
                query = query.Where(m => m.FacilNo == facilNo);
            }

            return query.OrderByDescending(o => o.UpdateDate);
        }

        //.Take(10).Skip(1)
        public IQueryable<Meter?> GetItem(int facilNo, string meterID) => this.GetList(facilNo).Where(m => m.MeterID.ToUpper() == meterID.ToUpper());

        public async Task<string> Update(int facilNo, string meterID, Meter meter, string forceUpdate = "D")
        {
            {
                if (facilNo != meter.FacilNo && meterID.ToUpper() != meter.MeterID.ToUpper())
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
            return _context.Meters.Any(e => e.FacilNo == facilNo && e.MeterID.ToUpper() == meterID.ToUpper());
        }
    }
}
