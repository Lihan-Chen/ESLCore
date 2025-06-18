using ESL.Core.Models.BusinessEntities;

namespace ESL.Application.Interfaces.IRepositories
{
    public interface ISubjectRepository
    {
        public IQueryable<Subject> GetSubject(int facilNo, int subjNo);
        public IQueryable<Subject> GetSubjectList(int facilNo);
    }
}