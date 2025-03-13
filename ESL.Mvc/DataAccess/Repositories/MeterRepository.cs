using Microsoft.EntityFrameworkCore;
using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using ESL.Mvc.DataAccess.Persistence;

namespace ESL.Mvc.DataAccess.Repositories
{
    public class MeterRepository : IMeterRepository // GenericRepository<Meter>, 
    {
        private readonly EslDbContext _context;
        private readonly ILogger<MeterRepository> _logger;
        private DbSet<Meter> _dbSet;

        public MeterRepository(
            EslDbContext context,
            ILogger<MeterRepository> logger
            ) // : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Meter>();
        }
        //public Task<string> GetFullName(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IEnumerable<Meter>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
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
                var existingMeter = await _dbSet.Where(x => x.MeterID == entity.MeterID).FirstOrDefaultAsync();

                if (existingMeter == null)
                    await _dbSet.AddAsync(entity, cancellationToken);

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

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var exist = await _dbSet.Where(x => x.MeterID == id).FirstOrDefaultAsync();

                if (exist == null) return false;

                _dbSet.Remove(exist);

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
