using ESL.Web.Models.BusinessEntities;
using System.Linq.Expressions;

namespace ESL.Web.Repositories
{
    public interface IFlowChangeRepository
    {
        Task<List<FlowChange>> GetAll();
        Task<FlowChange> Get(int facilNo, int logtypeno, int eventID, int eventID_RevNo);

        Task<IEnumerable<FlowChange>> Find(Expression<Func<FlowChange, bool>> predicate);
        Task<FlowChange> Add(FlowChange evententity);
        Task<FlowChange> Update(FlowChange entity);
        Task<FlowChange> Delete(int facilNo, int logtypeno, int eventID, int eventID_RevNo);
    }
}
