using ESL.Data;
using ESL.Models.BusinessEntities;

namespace ESL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Facility> FacilityRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }

        //ToDo
        // AllEvent and all other logs are base on another generic type
        // IRepository<AllEvent> AllEventRepositroy { get; }

        IFacilityRepository Facilities { get; }
        IEmployeeRepository Employees { get; }
        int Complete();
    }
}
