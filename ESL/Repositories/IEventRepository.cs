using ESL.API.Models.BusinessEntities;
using System.Linq.Expressions;

namespace ESL.API.Repositories
{
    public interface IEventRepository<E> where E : class, IEntity
    {
        Task<List<E>> GetAll();
        Task<E> Get(int facilNo, int logtypeno, int eventID, int eventID_RevNo);

        //ToDo: PagedList for filtered result
        IEnumerable<E> Find(Expression<Func<FlowChange, bool>> predicate);
        Task<E> Add(FlowChange evententity);
        Task<E> Update(FlowChange entity);
        Task<E> Delete(int facilNo, int logtypeno, int eventID, int eventID_RevNo);
    }
}
