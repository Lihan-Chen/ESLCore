using ESL.Application.Interfaces.IRepositories;
using ESL.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ESL.Infrastructure.DataAccess.Repositories
{
    public class UserRepository(EslDbContext context, ILogger<UserRepository> logger) : IUserRepository // GenericRepository<User>, 
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<UserRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<string?> GetFullName(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }

                var user = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeNo == id);

                if (user == null)
                {
                    return null;
                }

                return $"{user?.FirstName} {user?.LastName}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(UserRepository));

                return null!;
            }
        }

        //public async Task<IEnumerable<User>> GetAll()
        //{
        //    try
        //    {
        //        return await dbSet.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} GetAllAsync Method error", typeof(UserRepository));

        //        // null
        //        return new List<User>();
        //    }
        //}

        //public async Task Upsert(User entity, CancellationToken cancellationToken = default(CancellationToken))
        //{       
        //    try
        //    {
        //        var existingUser = dbSet.FirstOrDefaultAsync(x => x.EmployeeNo == entity.EmployeeNo);

        //        if (existingUser == null)
        //            await dbSet.AddAsync(entity, cancellationToken); ;

        //        //existingUser.FirstName = entity.FirstName;
        //        //existingUser.LastName = entity.LastName;
        //        //existingUser.Email = entity.Email;
        //        dbSet.Update(entity);


        //        //return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(UserRepository));
        //        //return false;
        //    }
        //}

        //public override async Task<bool> Delete(int id)
        //{
        //    try
        //    {
        //        var exist = await dbSet.Where(x => x.EmployeeNo == id).FirstOrDefaultAsync();

        //        if (exist == null) return false;

        //        dbSet.Remove(exist);

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(UserRepository));
        //        return false;
        //    }
        //}
    }
}
