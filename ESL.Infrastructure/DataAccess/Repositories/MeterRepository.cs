using Microsoft.EntityFrameworkCore;
using ESL.Application.Interfaces.IRepositories;
using ESL.Core.Models.BusinessEntities;
using ESL.Infrastructure.DataAccess;
using Microsoft.Extensions.Logging;

namespace ESL.Infrastructure.DataAccess.Repositories
{
    public class MeterRepository(
            EslDbContext context,
            ILogger<MeterRepository> logger
            ) : IMeterRepository // GenericRepository<Meter>, 
    {
        private readonly EslDbContext _context= context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<MeterRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<IEnumerable<Meter>> GetAll()
        {
            try
            {
                return await _context.Meters.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAllAsync Method error", typeof(MeterRepository));

                // null
                return new List<Meter>();
            }
        }

        public async Task Upsert(Meter entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingMeter = await _context.Meters.Where(x => x.MeterID.ToUpper() == entity.MeterID.ToUpper()).FirstOrDefaultAsync();

                if (existingMeter == null)
                    await _context.Meters.AddAsync(entity, cancellationToken);

                //existingMeter.FacilNo = entity.FacilNo;
                //existingMeter.MeterType = entity.MeterType;
                //existingMeter.UpdateDate = DateTime.Now;

                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(MeterRepository));
                //return false;
            }
        }

        public async Task<bool> DeleteAsync(string? meterID)
        {
            if (string.IsNullOrEmpty(meterID))
            {
                return false; // BadRequest();
            }

            try
            {
                var exist = await _context.Meters.Where(x => x.MeterID.ToUpper() == meterID.ToUpper()).FirstOrDefaultAsync();

                if (exist == null) return false;

                _context.Meters.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(MeterRepository));

                return false;
            }
        }

        public IQueryable<Meter> GetList(int? facilNo)
        {
            var query = _context.Meters.AsNoTracking().Where(m => m.Disable == null);

            if (facilNo is not null)
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
                if (facilNo != meter.FacilNo || meterID.ToUpper() != meter.MeterID.ToUpper())
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
