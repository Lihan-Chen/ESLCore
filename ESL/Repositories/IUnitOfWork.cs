using ESL.Data;
using ESL.Web.Models.BusinessEntities;

namespace ESL.Web.Repositories
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

        //public void Dispose();

    }
}
