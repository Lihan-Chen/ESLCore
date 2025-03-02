using ESL.Core.Data;
using ESL.Core.IConfiguration;
using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ESL.Core.Repositories
{
    public class EmployeeRepository : IEmployeeRepository // GenericRepository<Employee>, 
    {
        private EslDbContext _context;
        private DbSet<Employee> _employees;
        private ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(
            EslDbContext context,
            ILogger<EmployeeRepository> logger
            ) // : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _employees = context.Employees;
        }

        #region IQueryable

        // SQL = ESL.ESL_EMPLOYEELIST_PROC
        // SQL = ESL.ESL_EMPLOYEELIST_FACIL_PROC
        // IOrderedQueryable
        public IOrderedQueryable<Employee> GetListQuery(int? facilNo)
        {
            var query = _employees.AsNoTracking();

            if (facilNo != null)
            {
                query = query.Where(e => e.FacilNo == facilNo);
            }
            return query.Where(e => e.FacilNo == facilNo).Where(d => d.Disable == null || d.Disable != "Y").Distinct().OrderBy(o => o.LastName).ThenBy(o => o.FirstName);
        }

        // SQL = ESL.ESL_EMPLOYEELIST_EXT_PROC WHERE GROUPNAME LIKE '%WATER SYSTEM OPERATIONS GROUP%' AND LENGTH(EMPLOYEENO) <> 4
        public IQueryable<Employee> GetListExternalQuery()
        {
            var query = _employees.AsNoTracking();

            var keyWord = "%WATER SYSTEM OPERATIONS GROUP%";

            return _employees.AsNoTracking().Where(e => !(EF.Functions.Like(e.GroupName, keyWord)) && e.EmployeeNo.ToString().Length != 4).OrderBy(o => o.LastName).ThenBy(o => o.FirstName);
        }

        // SQL = SELECT * FROM ESL.ESL_EMPLOYEES WHERE EMPLOYEENO = 'employeeNo.ToString()'"
        public IQueryable<Employee> GetItemQuery(int? employeeNo)
        {
            return _employees.AsNoTracking().Where(e => e.EmployeeNo == employeeNo);
        }

        // SQL = SELECT ROLE FROM ESL.ESL_ALLSCADAUSERS_ROLE WHERE UPPER(USERID) = UPPER('UserID') AND FACILNO = facilNo
        public IQueryable<Employee> GetItemQuery(string firstName, string lastName)
        {
            return _employees.AsNoTracking().Where(e => e.FirstName == firstName && e.LastName == lastName);
        }

        public IQueryable<string> GetRoleByFacilityQuery(string? userID, int? facilNo)
        {
            return _context.Database.SqlQuery<string>($"SELECT ROLE FROM ESL.ESL_ALLSCADAUSERS_ROLE WHERE UPPER(USERID) = UPPER('{userID}') AND FACILNO = {facilNo}").AsNoTracking(); //.FirstOrDefault())
        }

        public async Task<int> Update(Employee employee)
        {
            //var commandText = "UPDATE Categories SET IsActiveStatus = ExpirationYear < 2019 WHERE a == b";
            //var name = new SqlParameter("@employeeNo", "5");
            //_context.Database.ExecuteSqlAsync(commandText, name, cancellationToken=default ); /*<params SqlParameter[]>*/

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.EmployeeNo))
                {
                    return 0; // NotFound();
                }
                else
                {
                    throw;
                }
            }

            return employee.EmployeeNo; // NoContent();
        }

        #endregion IQueryable

        public bool EmployeeExists(int employeeNo)
        {
            return _employees.AsNoTracking().Any(e => e.EmployeeNo == employeeNo);
        }

        public int ConvertToEmployeeNo(string userID)
        {
            return userID.IndexOf((char)0) == 1 ? Convert.ToInt32(userID.Substring(2)) : Convert.ToInt32(userID.Substring(1));
        }

        public string ConvertToUserID(int employeeNo)
        {
            return employeeNo.ToString().Length == 4 ? $"U0{employeeNo}" : $"U{employeeNo}";
        }

        #region Old Codes

        //public async Task<Employee?> GetEmployee(int employeeNo)
        //{
        //    var employee = await _employees.FindAsync(employeeNo);

        //    if (employee == null)
        //    {
        //        throw new Exception();  // new StreetwoodException(ErrorCode.GenericNotExist(typeof(T)));
        //    }

        //    return employee;
        //}

        //public override async Task<IEnumerable<Employee>> GetAll()
        //{
        //    try
        //    {
        //        return await _employees.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} GetAllAsync Method error", typeof(EmployeeRepository));

        //        // null
        //        return new List<Employee>();
        //    }
        //}

        //public override async Task Upsert(Employee entity)
        //{
        //    try
        //    {
        //        var existingEmployee = await _employees.FindAsync(entity.EmployeeNo); //Where(x => x.EmployeeNo == entity.EmployeeNo).FirstOrDefaultAsync();

        //        if (existingEmployee == null)
        //            await _employees.AddAsync(entity); // cancellationToken);

        //        //existingEmployee.FirstName = entity.FirstName;
        //        //existingEmployee.LastName = entity.LastName;
        //        //existingEmployee.FacilNo = entity.FacilNo;
        //        _employees.Update(entity);
        //        //_context.Entry<T>(entity).CurrentValues.SetValues(entity);              
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(EmployeeRepository));
        //    }
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return false;
        //        }

        //        var emp = await _employees.FindAsync(id);

        //        _employees.Remove(emp!);

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(EmployeeRepository));
        //        return false;
        //    }
        //}

        //public async Task<Employee?> GetEmployee(string firstName, string lastName)
        //{
        //    Employee? employee = await _employees.Where(e => e.FirstName.ToUpper() == firstName.ToUpper() && e.LastName.ToUpper() == lastName.ToUpper()).FirstOrDefaultAsync();

        //    //Employee? employee = await dbSet.FirstOrDefaultAsync(e => e.FirstName == firstName && e.LastName == lastName);

        //    if (employee == null)
        //    {
        //        throw new Exception();
        //    }

        //    return employee;
        //}

        #endregion Old Codes
    }
}
