using ESL.Core.Models;

namespace ESL.Core.IRepositories
{

    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<string> GetFullName(int employeeNo);

        Task<Employee> GetEmployee(string firstName, string lastName);
    }
}
