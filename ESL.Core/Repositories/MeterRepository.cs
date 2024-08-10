using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ESL.Core.IRepositories;
using ESL.Core.Data;
using ESL.Core.Models;

namespace ESL.Core.Repositories
{
    public class MeterRepository : GenericRepository<Meter>, IMeterRepository
    {

        public MeterRepository(
            ApplicationDbContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }
        //public Task<string> GetFullName(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public override async Task<IEnumerable<Meter>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAllAsync Method error", typeof(MeterRepository));

                // null
                return new List<Meter>();
            }
        }

        public async Task Upsert(Meter entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var existingMeter = await dbSet.Where(x => x.MeterID == entity.MeterID).FirstOrDefaultAsync();

                if (existingMeter == null)
                    await dbSet.AddAsync(entity, cancellationToken);

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

        public  async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.MeterID == id).FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(MeterRepository));
                return false;
            }
        }
    }
}
