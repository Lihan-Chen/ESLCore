using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;

namespace ESL.Mvc.Services
{
    public interface IEmployeeService
    {
        // Get Employee
        public Task<Employee?> GetEmployeeByEmployeeName(string employeeName);

        public Task<Employee?> GetEmployeeByEmployeeNo(int employeeNo);
        
        public Task<Employee?> GetEmployeeByEmployeeID(string employeeID);

        // Get FullName
        public Task<string?> GetFullNameByEmployeeNo(int employeeNo);

        public Task<string?> GetFullNameByEmployeeID(string EmployeeID);
        
        // Get EmployeeID integer
        public Task<int?> GetEmployeeNoByEmployeeName(string employeeName);
        
        // Get UserID string
        public Task<string?> GetEmployeeIDByEmployeeName(string employeeName);
               
        // Get Employee's FacilityNo              
        public Task<int?> GetEmployeeFacilNobyEmployeeName(string employeeName);

        public Task<string?> GetRole(string userID, int facilNo);

        //Facilities
        public Task<IEnumerable<Facility>> GetAllPlants();

        // For Selecting a plant (OCC, DOCC, pumping, treatment, DVL)
        public List<SelectListItem> GetPlantSelectList();

        public List<SelectListItem> GetFacilTypes();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employees;

        private readonly IFacilityRepository _facilities;

        private readonly IEmpRoleRepositry _empRoles;

        public EmployeeService(IEmployeeRepository employeeRepository, IFacilityRepository facilityRepository, IEmpRoleRepositry empRoleRepository)
        {
            _employees = employeeRepository;
            _facilities = facilityRepository;
            _empRoles = empRoleRepository;
        }

        // employeeFullName = lastName,firstName
        public async Task<Employee?> GetEmployeeByEmployeeName(string employeeFullName)
        {
            Employee? _employee = null;

            // LastName,FirstName format
            if (!string.IsNullOrEmpty(employeeFullName))
            {
                string firstName = employeeFullName.Split(',')[1];
                string lastName = employeeFullName.Split(',')[0];

                _employee = await _employees.GetEmployee(firstName, lastName);
            }

            return _employee;
        }

        // employeeNo = 12345
        public async Task<Employee?> GetEmployeeByEmployeeNo(int employeeNo) => await _employees.GetEmployee(employeeNo);

        public async Task<Employee?> GetEmployeeByEmployeeID(string employeeID)
        {
            Employee? _employee = null!;

            if (!string.IsNullOrEmpty(employeeID))
            {
                int _employeeNo = employeeID.Substring(0, 2).ToUpper() == "U0" ? Int32.Parse(employeeID.Substring(2)) : Int32.Parse(employeeID.Substring(1));

                // int _userEmployeeNo = userID.Substring(0, 2).ToUpper() == "U0" ? Convert.ToInt32(userID.Substring(2)) : Convert.ToInt32(userID.Substring(1));

                _employee = await GetEmployeeByEmployeeNo(_employeeNo);
            }

            return _employee;
        }

        // Get FullName
        public async Task<string?> GetFullNameByEmployeeNo(int employeeNo)
        {
            Employee? _employee = await GetEmployeeByEmployeeNo(employeeNo);

            return _employee?.FullName;

        }
        public async Task<string?> GetFullNameByEmployeeID(string employeeID)
        {
            Employee? _employee = await GetEmployeeByEmployeeID(employeeID);

            return _employee?.FullName;
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

                    _employee = await _employees.GetEmployee(firstName, lastName);
                }

                _employeeNo = _employee.EmployeeNo;

                //return employee?.EmployeeNo;
            }

            return _employeeNo;
        }

        // Get UserID string
        public async Task<string?> GetEmployeeIDByEmployeeName(string employeeName)
        {
            int? _employeeNo = await GetEmployeeNoByEmployeeName(employeeName);

            return _employeeNo < 10000 ? $"U{_employeeNo?.ToString("D4")}" : $"U{ _employeeNo?.ToString("D5")}";            
        }

        // Get Employee's FacilityNo              
        public async Task<int?> GetEmployeeFacilNobyEmployeeName(string employeeName)
        {
            int? _facilNo;

            Employee? employee = await GetEmployeeByEmployeeName(employeeName);
            
            _facilNo = employee?.FacilNo;

            return _facilNo;
        }

        // Get Employee's role per Facility
        public async Task<string?> GetRole(string userID, int facilNo)
        {
            return await _empRoles.GetRole(userID, facilNo);
        }

        public async Task<bool> IsInRole(string userID, string role, int facilNo)
        {
            switch(role)
            {
                case "ESL_OPERATOR":
                    return await _empRoles.IsInRole(userID, role, facilNo) ||
                           await _empRoles.IsInRole(userID, "ESL_ADMIN", facilNo) ||
                           await _empRoles.IsInRole(userID, "ESL_SUPERADMIN", facilNo);
            
                case "ESL_ADMIN":
                    return await _empRoles.IsInRole(userID, role, facilNo) ||
                           await _empRoles.IsInRole(userID, "ESL_SUPERADMIN", facilNo);

                case "ESL_SUPERADMIN":
                    return  await _empRoles.IsInRole(userID, role, facilNo);

                default:
                    return false;
            }
        }
        // Facilities and Plants

        public async Task<IEnumerable<Facility>> GetAllPlants() => await _facilities.GetAll();

        // For Selecting a plant (OCC, DOCC, pumping, treatment, DVL)
        public List<SelectListItem> GetPlantSelectList() => _facilities.GetFacilAbbrList();

        public List<SelectListItem> GetFacilTypes() => _facilities.GetFacilTypes();

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
