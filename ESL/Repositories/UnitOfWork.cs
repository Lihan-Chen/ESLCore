using ESL.Data;
using ESL.Web.Models.BusinessEntities;

namespace ESL.Web.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }
        public IRepository<Facility> FacilityRepository => new Repository<Facility>(db);

        public IRepository<Employee> EmployeeRepositroy => new Repository<Employee>(db);

        //public IRepository<Instructor> InstructorRepository => new Repository<Instructor>(db);

        public IFacilityRepository Facilities => new FacilityRepository(db);
        public IEmployeeRepository Employees => new EmployeeRepository(db);

        public int Complete()
        {
            return db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
