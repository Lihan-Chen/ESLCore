using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.DAL;
using System.ComponentModel;

namespace ESL.Api.Models.IRepositories
{
    public interface IEmployeeRepository
    {
        #region
        /// <summary>
        /// Gets a list of Employees
        /// Maps to public static EmployeeList GetList()
        /// </summary>
        /// <param>None</param>
        /// <returns>A list with Employee objects when the database contains Employees for the parameters specified, or an empty list otherwise.</returns>
        //public Task<List<Employee>> GetList();

        public IOrderedQueryable<Employee> GetListQuery(int? facilNo);

        /// <summary>
        /// Gets a list of Employees
        /// Maps to public static EmployeeList GetListByFacilNo(int facilNo)
        /// </summary>
        /// <param name="facilNo">The unique No of the Facility in the database.</param>
        /// <returns>A list with Employee objects when the database contains Employees for the parameters specified, or an empty list otherwise.</returns>


        public Task<List<Employee>> GetListByFacilNo(int facilNo);

        /// <summary>
        /// Gets a list of extermal Employees
        /// Maps to public static EmployeeList GetListByFacilNo(int facilNo)
        /// </summary>
        /// <param name="facilNo">The unique No of the Facility in the database.</param>
        /// <returns>A list with Employee objects when the database contains Employees for the parameters specified, or an empty list otherwise.</returns>
        public IQueryable<Employee> GetListExternalQuery();

        /// <summary>
        /// Gets a single Employee from the database by its EmployeeNo.
        /// </summary>
        /// <param name="employeeNo">The unique EmployeeNo of the Employee in the database.</param>
        /// <returns>An FlowChange object when the record exists in the database, or <see langword="null"/> otherwise.</returns>
        public Task<Employee> GetItem(int employeeNo);

        /// <summary>
        /// Gets the role of the Employee from the database by its EmployeeNo.
        /// Maps to public static string GetRole(string userID, int facilNo)
        /// </summary>
        /// <param name="employeeNo">The unique Employee No in the database.</param>
        /// /// <param name="facilNo">The unique Facil No in the database.</param>
        /// <returns>A string of role when the record exists in the database, or <see langword="null"/> otherwise.</returns>
        public Task<string> GetRole(string userID, int facilNo);

        /// <summary>
        /// Updates an Employee record in the database.
        /// Maps to public static int Update(Employee myEmployee)
        /// </summary>
        ///<param name="myEmployee">The Employee instance to save.</param>
        ///<returns>The new employeeNo if the FlowChange is new in the database or the existing employeeNo when an item was updated.</returns>
        public Task<int> Update(Employee employee);

        #endregion
    }
}
