using ESL.Core.Data;
using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Repositories
{
    public class ConstantRepository : GenericRepository<Constant> //, IFacilityRepository
    {

        public ConstantRepository(
            ApplicationDbContext context,
            ILogger logger
            ) : base(context, logger)
        {
        }
    }
}
