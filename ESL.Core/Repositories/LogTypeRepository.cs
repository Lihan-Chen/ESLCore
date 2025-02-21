using ESL.Core.Data;
using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Repositories
{
    internal class LogTypeRepository : GenericRepository<LogType>, ILogTypeRepository
    {
        public LogTypeRepository(
            EslDbContext context,
            ILogger<LogTypeRepository> logger
            ) : base(context, logger)
        {
        }

        public async Task<LogType> GetLogType(int LogTypeNo) => await dbSet.FirstOrDefaultAsync(l => l.LogTypeNo == LogTypeNo);

        public async Task<LogType> GetLogType(string LogTypeName) => await dbSet.FirstOrDefaultAsync(l => l.LogTypeName == LogTypeName);
          
        public async Task<List<LogType>> GetLogTypes() => await dbSet.AsQueryable().AsNoTracking().ToListAsync();
        
        public async Task<string> GetLogTypeName(int LogTypeNo) => await GetLogType(LogTypeNo).ContinueWith(t => t.Result.LogTypeName);
        
        public async Task<int> GetLogTypeNo(string LogTypeName) => await GetLogType(LogTypeName).ContinueWith(t => t.Result.LogTypeNo);

        public async virtual Task<SelectList> GetLogTypeSelectList()
        {
            var logTypeList = await GetLogTypes();
            // return new SelectList(logTypeList, "LogTypeNo", "LogTypeName");
            return new SelectList(logTypeList, nameof(LogType.LogTypeNo), nameof(LogType.LogTypeName));
        }
    }
}
