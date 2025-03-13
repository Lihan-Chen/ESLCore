using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using ESL.Mvc.DataAccess.Persistence;

namespace ESL.Mvc.DataAccess.Repositories
{
    public class ConstantRepository : IConstantRepository //, IFacilityRepository GenericRepository<Constant>, 
    {

        public ConstantRepository(
            EslDbContext context,
            ILogger<ConstantRepository> logger
            ) // : base(context, logger)
        {
        }


        public Task<Constant> GetConstant(int facilNo, string constantName, DateTime? startDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Constant>> GetConstantsByFacil(int facilNo)
        {
            //return dbSet.Where(x => x.FacilNo == facilNo).FirstOrDefault();
            throw new NotImplementedException();
        }



        public Task<int> Update(Constant constant, string forceUpdate)
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
