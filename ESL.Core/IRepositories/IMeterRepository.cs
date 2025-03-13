using ESL.Core.Models.BusinessEntities;

namespace ESL.Core.IRepositories
{
    public interface IMeterRepository 
    {
        public Task<IEnumerable<Meter>> GetAll();

        public Task Upsert(Meter entity, CancellationToken cancellationToken = default(CancellationToken));

        public Task<bool> DeleteAsync(string id);
    }
}
