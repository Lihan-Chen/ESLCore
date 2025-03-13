using ESL.Core.Data;
using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ESL.Core.Repositories
{
    public class LogTypeRepository : ILogTypeRepository // GenericRepository<LogType>, 
    {
        private readonly EslDbContext _context;
        private readonly ILogger<LogTypeRepository> _logger;
        private DbSet<LogType> _dbSet;

        public LogTypeRepository(
            EslDbContext context,
            ILogger<LogTypeRepository> logger
            ) // : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<LogType>();
        }

        public async Task<LogType> GetLogType(int LogTypeNo) => await _dbSet.FirstOrDefaultAsync(l => l.LogTypeNo == LogTypeNo);

        public async Task<LogType> GetLogType(string LogTypeName) => await _dbSet.FirstOrDefaultAsync(l => l.LogTypeName == LogTypeName);
          
        public async Task<List<LogType>> GetLogTypes() => await _dbSet.AsQueryable().AsNoTracking().ToListAsync();
        
        public async Task<string> GetLogTypeName(int LogTypeNo) => await GetLogType(LogTypeNo).ContinueWith(t => t.Result.LogTypeName);
        
        public async Task<int> GetLogTypeNo(string LogTypeName) => await GetLogType(LogTypeName).ContinueWith(t => t.Result.LogTypeNo);

        public async Task<List<string>> GetLogTypeList() => await _dbSet.Select(l => l.LogTypeName).Distinct().ToListAsync();
        //{
        //    return await _dbSet.Select(l => l.LogTypeName).Distinct().ToListAsync();
            
            //var logTypeList = await GetLogTypes();
            //// return new SelectList(logTypeList, "LogTypeNo", "LogTypeName");
            //return new SelectList(logTypeList, nameof(LogType.LogTypeNo), nameof(LogType.LogTypeName));
        //}
    }
}
