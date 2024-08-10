using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ESL.Core.IRepositories;
using ESL.Core.Data;
using ESL.Core.Models;
using ESL.Core.Repositories;
using System.Threading;

namespace ESL.Core.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(
            ApplicationDbContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }
        public async Task<string> GetFullName(int id)
        {
            var employee = await dbSet.FindAsync(id);

            if (employee == null)
            {
                throw new Exception();  // new StreetwoodException(ErrorCode.GenericNotExist(typeof(T)));
            }

            return employee?.User.FullName; 
        }

        public override async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAllAsync Method error", typeof(EmployeeRepository));

                // null
                return new List<Employee>();
            }
        }

        public override async Task Upsert(Employee entity)
        {
            try
            {
                var existingEmployee = await dbSet.Where(x => x.EmployeeNo == entity.EmployeeNo).FirstOrDefaultAsync();

                if (existingEmployee == null)
                   await dbSet.AddAsync(entity); // cancellationToken);

                //existingEmployee.FirstName = entity.FirstName;
                //existingEmployee.LastName = entity.LastName;
                //existingEmployee.FacilNo = entity.FacilNo;
                dbSet.Update(entity);
                //_context.Entry<T>(entity).CurrentValues.SetValues(entity);
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(EmployeeRepository));
            }
        }

        public async Task<bool> DeleteAsync(int id)
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
                _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(EmployeeRepository));
                return false;
            }
        }
    }
}
