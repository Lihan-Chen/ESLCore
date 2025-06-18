
using ESL.Application.Interfaces.IRepositories;
using ESL.Core.Models.BusinessEntities;
using ESL.Infrastructure.DataAccess;
using Microsoft.Extensions.Logging;

namespace ESL.Infrastructure.DataAccess.Repositories
{
    public class ConstantRepository(
            EslDbContext context,
            ILogger<ConstantRepository> logger
            ) : IConstantRepository //, IFacilityRepository GenericRepository<Constant>, 
    {

        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<ConstantRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        
        public IQueryable<EslConstant> GetConstant(int facilNo, string constantName, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EslConstant> GetConstantsByFacil(int facilNo)
        {
            //return dbSet.Where(x => x.FacilNo == facilNo).FirstOrDefault();
            throw new NotImplementedException();
        }

        public Task<int> Update(EslConstant constant, string forceUpdate)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Constant>> GetConstants(int facilNo)
        //{
        //    try
        //    {
        //        // var constants = await dbSet.Where(x => x.FacilNo == facilNo).FirstOrDefault(); //.FirstOrDefaultAsync();
        //        //return await dbSet.Where(x => x.FacilNo == facilNo).FirstOrDefault();
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(UserRepository));
        //        return null!;
        //    }
        //}
    }
}
