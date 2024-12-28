using System.Threading.Tasks;
using ESL.Core.Models.BusinessEntities;

namespace ESL.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<string> GetFullName(int id);
    }
}
