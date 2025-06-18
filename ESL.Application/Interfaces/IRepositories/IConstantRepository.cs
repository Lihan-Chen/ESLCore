using ESL.Core.Models.BusinessEntities;

namespace ESL.Application.Interfaces.IRepositories
{
    public interface IConstantRepository // : IGenericRepository<Constant>
    {
        public IQueryable<EslConstant> GetConstantsByFacil(int facilNo);

        public IQueryable<EslConstant> GetConstant(int facilNo, string constantName, DateTime startDate);

        public Task<int> Update(EslConstant constant, string forceUpdate);

        //public Task<List<Constant>> GetConstants(int facilNo);
    }
}