using ESL.Core.Models.BusinessEntities;

namespace ESL.Application.Interfaces.IServices
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
        public Task<bool> IsInRole(string userID, string role, int facilNo);

        //Facilities
        public Task<IEnumerable<Facility>> GetAllPlants();

        public Task<Facility?> GetFacility(int? facilNo);

        // For Selecting a plant (OCC, DOCC, pumping, treatment, DVL)
        public Task<List<Facil>> GetFaciList();

        //public Task<SelectList> GetFacilSelectList(int? facilNo);

        public Task<List<string>> GetFacilTypeList();

        public Task<List<string>> GetLogTypeList();

        //public Task<SelectList> GetFacilTypeSelectList();

        //public Task<SelectList> GetLogTypeSelectList(int? logTypeNo);

        //public Task<SelectList> GetLogTypeSelectList();
    }
}
