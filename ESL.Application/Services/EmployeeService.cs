using ESL.Application.Interfaces.IRepositories;
using ESL.Application.Interfaces.IServices;
using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace ESL.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employees;

        private readonly IFacilityRepository _facilities;

        private readonly IEmpRoleRepository _empRoles;

        private readonly ILogTypeRepository _logTypes;

        public EmployeeService(IEmployeeRepository employeeRepository, IFacilityRepository facilityRepository, IEmpRoleRepository empRoleRepository, ILogTypeRepository logTypeRepository)
        {
            _employees = employeeRepository;
            _facilities = facilityRepository;
            // _logTypes = logTypeRepository;
            _empRoles = empRoleRepository;
            _logTypes = logTypeRepository;
        }

        #region EmployeeService
        // employeeFullName = lastName,firstName 
        public async Task<Employee?> GetEmployeeByEmployeeName(string employeeFullName)
        {
            Employee? _employee = null;

            // LastName,FirstName format
            if (!string.IsNullOrEmpty(employeeFullName))
            {
                string firstName = employeeFullName.Split(',')[1];
                string lastName = employeeFullName.Split(',')[0];

                _employee = await _employees.GetItemQuery(firstName, lastName).FirstOrDefaultAsync();
            }

            return _employee;
        }

        // employeeNo = 12345
        public async Task<Employee?> GetEmployeeByEmployeeNo(int employeeNo) => await _employees.GetItemQuery(employeeNo).FirstOrDefaultAsync();

        public async Task<Employee?> GetEmployeeByEmployeeID(string employeeID)
        {
            Employee? _employee = null!;

            if (!string.IsNullOrEmpty(employeeID))
            {
                int _employeeNo = employeeID.Substring(0, 2).ToUpper() == "U0" ? Int32.Parse(employeeID.Substring(2)) : Int32.Parse(employeeID.Substring(1));

                _employee = await GetEmployeeByEmployeeNo(_employeeNo);
            }

            return _employee;
        }

        // Get FullName = lastName,firstName
        public async Task<string?> GetFullNameByEmployeeNo(int employeeNo)
        {
            Employee? _employee = await GetEmployeeByEmployeeNo(employeeNo);

            return $"{_employee?.FirstName} {_employee?.LastName}";

        }
        public async Task<string?> GetFullNameByEmployeeID(string employeeID)
        {
            Employee? _employee = await GetEmployeeByEmployeeID(employeeID);

            return $"{_employee?.FirstName} {_employee?.LastName}";
        }

        // Get EmployeeNo integer
        public async Task<int?> GetEmployeeNoByEmployeeName(string employeeName)
        {
            int? _employeeNo = -1;

            if (!string.IsNullOrEmpty(employeeName))
            {
                //Employee? employee = await GetEmployeeByEmployeeName(employeeName);

                Employee? _employee = null;

                // LastName,FirstName format
                if (!string.IsNullOrEmpty(employeeName))
                {
                    string firstName = employeeName.Split(',')[1];
                    string lastName = employeeName.Split(',')[0];

                    _employee = await _employees.GetItemQuery(firstName, lastName).FirstOrDefaultAsync();
                }

                _employeeNo = _employee!.EmployeeNo;

                //return employee?.EmployeeNo;
            }

            return _employeeNo;
        }

        // Get UserID string
        public async Task<string?> GetEmployeeIDByEmployeeName(string employeeName)
        {
            int? _employeeNo = await GetEmployeeNoByEmployeeName(employeeName);

            return _employeeNo < 10000 ? $"U{_employeeNo?.ToString("D4")}" : $"U{_employeeNo?.ToString("D5")}";
        }

        // Get Employee's FacilityNo              
        public async Task<int?> GetEmployeeFacilNobyEmployeeName(string employeeName)
        {
            int? _facilNo;

            Employee? employee = await GetEmployeeByEmployeeName(employeeName);

            _facilNo = employee?.FacilNo;

            return _facilNo;
        }
        #endregion EmployeeService

        #region RoleService
        // Get Employee's role per Facility
        public async Task<string?> GetRole(string userID, int facilNo)
        {
            return await _empRoles.GetRole(userID, facilNo);
        }

        public Task<bool> IsInRole(string userID, string role, int facilNo)
        {
            switch (role)
            {
                case "ESL_OPERATOR":
                    return Task.FromResult(
                        _empRoles.IsInRole(userID, role, facilNo) ||
                        _empRoles.IsInRole(userID, "ESL_ADMIN", facilNo) ||
                        _empRoles.IsInRole(userID, "ESL_SUPERADMIN", facilNo)
                    );

                case "ESL_ADMIN":
                    return Task.FromResult(
                        _empRoles.IsInRole(userID, role, facilNo) ||
                        _empRoles.IsInRole(userID, "ESL_SUPERADMIN", facilNo)
                    );

                case "ESL_SUPERADMIN":
                    return Task.FromResult(
                        _empRoles.IsInRole(userID, role, facilNo)
                    );

                default:
                    return Task.FromResult(false);
            }
        }

        #endregion RoleService

        #region FacilityService
        // Facilities and Plants

        // ConfigureAwait(false) allows the continuation to run on a different thread, which can improve performance and avoid deadlocks in certain scenarios
        // https://github.com/PiranhaCMS/piranha.core/tree/master
        public Task<IEnumerable<Facility>> GetAllPlants() => (Task<IEnumerable<Facility>>)_facilities.GetAll().AsAsyncEnumerable();

        public Task<Facility?> GetFacility(int? facilNo) => _facilities.GetFacility((int)facilNo!).FirstOrDefaultAsync();

        // For Selecting a plant (OCC, DOCC, pumping, treatment, DVL)
        public Task<List<string>> GetFacilTypeList() => _facilities.GetFacilTypeList().ToListAsync();

        public Task<List<Facil>> GetFaciList() =>  _facilities.GetFacilList().ToListAsync();

        //public async Task<SelectList> GetFacilSelectList(int? facilNo) // => new SelectList(await _facilities.GetFacilList(), "FacilNo", "FacilAbbr", facilNo);
        //{
        //    var _facilList = await _facilities.GetFacilList().ToListAsync();
        //    return new SelectList(_facilList.Select(x => new { value = x.FacilNo, text = x.FacilName.Split(' ').ElementAt(0) }), "FacilNo", "FacilName", facilNo);
        //}

        //public async Task<SelectList> GetFacilTypeSelectList() => new SelectList(await _facilities.GetFacilTypeList().ToListAsync(), "FacilType", "FacilType");

        #endregion FacilityService

        #region LogTypeService

        public async Task<List<string>> GetLogTypeList() => await _logTypes.GetLogTypeList().ToListAsync();

        #endregion LogTypeService

        //public async Task<SelectList> GetLogTypeSelectList(int? logTypeNo) => new SelectList(await _logTypes.GetLogTypeList().ToListAsync(), "LogTypeNo", "LogTypeName", logTypeNo);

        //public async Task<SelectList> GetLogTypeSelectList() => new SelectList(await _logTypes.GetLogTypeList().ToListAsync(), "LogTypeName", "LogTypeName");

        Task<Employee?> IEmployeeService.GetEmployeeByEmployeeName(string employeeName)
        {
            Employee? _employee = null;

            // LastName,FirstName format
            if (string.IsNullOrEmpty(employeeName)) return null;
            
            string firstName = employeeName.Split(',')[1];
            string lastName = employeeName.Split(',')[0];
            
            return _employees.GetItemQuery(firstName, lastName).FirstOrDefaultAsync();
        }

        Task<Employee?> IEmployeeService.GetEmployeeByEmployeeNo(int employeeNo)
        {
            return _employees.GetItemQuery(employeeNo).FirstOrDefaultAsync();
        }

        Task<Employee?> IEmployeeService.GetEmployeeByEmployeeID(string employeeID)
        {
            int.TryParse(employeeID.Substring(1), out int employeeNo);

            return _employees.GetItemQuery(employeeNo).FirstOrDefaultAsync();
        }

        Task<IEnumerable<Facility>> IEmployeeService.GetAllPlants() => (Task<IEnumerable<Facility>>)_facilities.GetFacilities().AsEnumerable();

        Task<Facility?> IEmployeeService.GetFacility(int? facilNo)
        {
            return _facilities.GetFacility(facilNo).FirstOrDefaultAsync();
        }

        Task<List<Facil>> IEmployeeService.GetFaciList()
        {
            return _facilities.GetFacilList().ToListAsync();
        }

        //public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        //{
        //    return from item in items
        //           select new SelectListItem
        //           {
        //               Text = item.GetPropertyValue("Name"),
        //               Value = item.GetPropertyValue("Id"),
        //               Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
        //           };
        //}

    }
}
