using ESL.Core.Models.BusinessEntities;

namespace ESL.Core.IRepositories
{
    public interface IConstantRepository : IGenericRepository<Constant>
    {
        public Task<List<Constant>> GetConstantsByFacil(int facilNo);

        public Task<Constant> GetConstant(int facilNo, string constantName, DateTime? startDate);

        public Task<int> Update(Constant constant, string forceUpdate);
    }
}