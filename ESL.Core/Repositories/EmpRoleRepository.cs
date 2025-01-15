using ESL.Core.Data;
using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Repositories
{
    public class EmpRoleRepository : IEmpRoleRepositry
    {
        protected EslDbContext _context;

        internal DbSet<AllScadaUsersRole> _roles;

        protected readonly ILogger<AllScadaUsersRole> _logger;

        public EmpRoleRepository(
            EslDbContext context,
            ILogger<AllScadaUsersRole> logger
            )
        {
            _context = context;
            _roles = context.Roles;
            _logger = logger;
        }

        public EmpRoleRepository(EslDbContext context, ILogger logger)
        {
        }

        public async Task<String?> GetRole(string userID, int facilNo)
        {
            if (facilNo == 0)
            {
                return await _roles.Where(r => r.UserID == userID).OrderBy(o => o.FacilNo).Select(s => s.DefaultRole).FirstOrDefaultAsync(); ;
            }

            return await _roles.Where(r => r.UserID == userID && r.FacilNo == facilNo).Select(s => s.DefaultRole).FirstOrDefaultAsync();
        }
    }
}
