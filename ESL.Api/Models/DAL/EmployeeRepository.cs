using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.IRepositories;
using ESL.Api.Models.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESL.Api.Models.DAL
{
    #region
    public partial class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext _context;

        private ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(
            ApplicationDbContext context,
            ILogger<EmployeeRepository> logger
            ) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // SQL = ESL.ESL_EMPLOYEELIST_PROC
        public IOrderedQueryable<Employee> GetListQuery(int? facilNo)
        {
            var query = _context.Employees.AsNoTracking();

            if (facilNo != null)
            {
                query = query.Where(e => e.FacilNo == facilNo);
            }
            return query.Where(d => d.Disable == null || d.Disable != "Y").Distinct().OrderBy(o => o.LastName).ThenBy(o => o.FirstName);
        }


        public string UserID(int employeeNo) => employeeNo.ToString().Length == 4 ? $"U0{employeeNo}" : $"U{employeeNo}";

        // SQL = ESL.ESL_EMPLOYEELIST_FACIL_PROC
        public IQueryable<Employee> GetListByFacilNo(int facilNo)
        {
            var query = _context.Employees.AsNoTracking();

            if (facilNo != 0)
            {
                query = query.Where(e => e.FacilNo == facilNo);
            }

            return query.Where(d => d.Disable == null || d.Disable != "Y").Distinct().OrderBy(o => o.LastName).ThenBy(o => o.FirstName);
            //return await _context.Employees.Where(m => m.FacilNo == facilNo && m.Disable == null).OrderBy(o => o.LastName).ThenBy(o => o.FirstName).AsNoTracking().ToListAsync(); //.Take(10).Skip(1)
        }

        // SQL = ESL.ESL_EMPLOYEELIST_EXT_PROC WHERE GROUPNAME LIKE '%WATER SYSTEM OPERATIONS GROUP%' AND LENGTH(EMPLOYEENO) <> 4
        public IQueryable<Employee> GetListExternalQuery()
        {
            //var keyWord = "%WATER SYSTEM OPERATIONS GROUP%";

            var keyWord = "%WATER SYSTEM OPERATIONS GROUP%";

            return _context.Employees.AsNoTracking().Where(e => !(EF.Functions.Like(e.GroupName, keyWord)) && e.EmployeeNo.ToString().Length != 4).OrderBy(o => o.LastName).ThenBy(o => o.FirstName);

            //return await _context.Employees.Where(e => !EF.Functions.Like(e.GroupName, keyWord) && e.EmployeeNo.ToString().Length != 4).OrderBy(o => o.LastName).ThenBy(o => o.FirstName).AsNoTracking().ToListAsync();
        }

        // SQL = SELECT * FROM ESL.ESL_EMPLOYEES WHERE EMPLOYEENO = 'employeeNo.ToString()'"
        public async Task<Employee> GetItem(int employeeNo)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNo == employeeNo);
        }

        // SQL = SELECT ROLE FROM ESL.ESL_ALLSCADAUSERS_ROLE WHERE UPPER(USERID) = UPPER('UserID') AND FACILNO = facilNo
        public async Task<string> GetRole(string userID, int facilNo) => await ESL_ROLEBYFACIL(_context, userID, facilNo);
        
        private async Task<string> ESL_ROLEBYFACIL(ApplicationDbContext context, string userID, int facilNo) => 
            context.Database.SqlQuery<string>($"SELECT ROLE FROM ESL.ESL_ALLSCADAUSERS_ROLE WHERE UPPER(USERID) = UPPER('{userID}') AND FACILNO = {facilNo}").FirstOrDefault();

        

        ////int _employeeNo = UserIDToEmployeeN(userID);
        //string p_sql = "ESL.ESL_GETEMPLOYEEROLEBYFACIL";
        //string sql = "SELECT ROLE FROM ESL.ESL_ALLSCADAUSERS_ROLE WHERE UPPER(USERID) = UPPER('UserID') AND FACILNO = facilNo";

        //// this is on AllScadaUsersRoles
        //return await _context.Database.ExecuteSql("ESL.ESL_GETEMPLOYEEROLEBYFACIL @p0, @p1", parameters: new[] { userID, facilNo }); //(sql).Where(e => e.EmployeeNo == userID && e.FacilNo == facilNo).Select(x.GetRole(userID, facilNo);

        //// throw new NotImplementedException();

        //return string.Empty;

        public async Task<int> Update(Employee employee)
        {
            //if (employee.facilNo != meter.FacilNo && meterID != meter.MeterID)
            //{
            //    return "Bad Request"; // BadRequest();
            //}

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

        private string ESL_GETROLEBYFACIL(ApplicationDbContext context, string userID, int facilNo) =>
        
            context.Database.SqlQuery<string>($"SELECT ROLE FROM ESL.ESL_ALLSCADAUSERS_ROLE WHERE UPPER(USERID) = UPPER('{userID}') AND FACILNO = {facilNo}").FirstOrDefault();

        //{            
        //var roleParameter = new SqlParameter()
        //{
        //    ParameterName = "Role",
        //    SqlDbType = System.Data.SqlDbType.VarChar,
        //    Direction = System.Data.ParameterDirection.Output
        //};
        //SELECT ROLE FROM ESL.ESL_ALLSCADAUSERS_ROLE WHERE UPPER(USERID) = UPPER('UserID') AND FACILNO = facilNo//new SqlParameter("@inUserID", userID),
        //string _role = _context.Database.FromSql("ESL_GETEMPLOYEEROLEBYFACIL @inUserID, @inFacilNo, @Role OUTPUT", userID, facilNo, roleParameter);
        //new SqlParameter("@inUserID", userID),
        //new SqlParameter("@inFacilNo", facilNo),
        //roleParameter);

        //}

        //public async Task<string> Delete(int employeeNo, string meterID)
        //{
        //    var meter = await _context.Meters.FindAsync(facilNo, meterID);
        //    if (meter == null)
        //    {
        //        return "Not Found"; //NotFound();
        //    }

        //    _context.Meters.Remove(meter);
        //    await _context.SaveChangesAsync();

        //    return meterID; //  NoContent();
        //}

        #endregion

        private bool EmployeeExists(int employeeNo)
        {
            return _context.Employees.Any(e => e.EmployeeNo == employeeNo);
        }

        private int UserIDToEmployeeNo(string userID)
        { 
                return userID.IndexOf((char)0) == 1 ? Convert.ToInt32(userID.Substring(2)) : Convert.ToInt32(userID.Substring(1));
        }

        private string EmployeeNoToUserID(int employeeNo)
        {
            return employeeNo.ToString().Length == 4 ? $"U0{employeeNo}" : $"U{employeeNo}";
        }

    }
}
