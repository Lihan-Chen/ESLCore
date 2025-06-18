using System.Threading.Tasks;
using ESL.Core.Models.BusinessEntities;

namespace ESL.Application.Interfaces.IRepositories
{
    public interface IUserRepository // : IGenericRepository<User>
    {
        public Task<string?> GetFullName(int? id);
    }
}
