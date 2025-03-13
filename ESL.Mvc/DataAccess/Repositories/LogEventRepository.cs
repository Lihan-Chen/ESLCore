using Microsoft.EntityFrameworkCore;
using ESL.Core.IRepositories;
using ESL.Core.Data;
using ESL.Core.IConfiguration;
using ESL.Core.Models;
using ESL.Core.Models.ComplexTypes;
using System;
using System.Linq.Expressions;

using System.Net.WebSockets;
using Microsoft.Extensions.Logging;
using ESL.Mvc.Data;

namespace ESL.Mvc.Data.Repositories
{
    public class LogEventRepository<TEntity> // : ILogEventRepository<TEntity> where TEntity : LogEvent
    {
        protected EslDbContext _context;

        internal DbSet<TEntity> dbSet;

        protected readonly ILogger _logger;

        public LogEventRepository(EslDbContext context, ILogger logger)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
            _logger = logger;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo)
        {
            var result = await dbSet.SingleOrDefaultAsync(e => e.FacilNo == FacilNo & e.LogTypeNo == LogTypeNo & e.EventID == EventID & e.EventID_RevNo == EventID_RevNo);

            if (result == null)
            {
                throw new Exception($"{typeof(TEntity)}NotExist");
            }

            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            // return dbSet.Where(predicate).ToListAsync();
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> DeleteAsync(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo)
        {
            throw new NotImplementedException();
        }


        public virtual Task<bool> UpsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
