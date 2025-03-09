using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ESL.Core.IRepositories;
using ESL.Core.Data;
using ESL.Core.Models.BusinessEntities;

namespace ESL.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(
            EslDbContext context,
            ILogger logger
            ) : base(context, logger)
        {
            
        }
        public async Task<string> GetFullName(int id)
        {
            try
            {
                var user = await dbSet.Where(x => x.EmployeeNo == id).FirstOrDefaultAsync();
                    return $"{user?.FirstName} {user?.LastName}";                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(UserRepository));
                return null!;
            }
        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAllAsync Method error", typeof(UserRepository));
                
                // null
                return new List<User>();
            }
        }

        public async Task Upsert(User entity, CancellationToken cancellationToken = default(CancellationToken))
        {       
            try
            {
                var existingUser = dbSet.FirstOrDefaultAsync(x => x.EmployeeNo == entity.EmployeeNo);

                if (existingUser == null)
                    await dbSet.AddAsync(entity, cancellationToken); ;

                //existingUser.FirstName = entity.FirstName;
                //existingUser.LastName = entity.LastName;
                //existingUser.Email = entity.Email;
                dbSet.Update(entity);


                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(UserRepository));
                //return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.EmployeeNo == id).FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(UserRepository));
                return false;
            }
        }
    }
}
