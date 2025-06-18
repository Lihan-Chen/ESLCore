using ESL.Application.Interfaces;
using ESL.Application.Interfaces.IRepositories;
using ESL.Infrastructure.DataAccess;
using ESL.Infrastructure.DataAccess.Repositories;

namespace ESL.Mvc.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EslDbContext _context;
        private readonly ILogger<UnitOfWork> _logger;

        public IEmployeeRepository Employees { get; private set; }
        public IEmpRoleRepository EmpRoles { get; private set; }
        public IConstantRepository Constants { get; private set; }
        public IFacilityRepository Facilities { get; private set; }
        public ILogTypeRepository LogTypes { get; private set; }
        public IMeterRepository Meters { get; private set; }
        public IAllEventRepository AllEvents { get; private set; }
        public ISubjectRepository Subjects { get; private set; }

        public ISearchDTORepository SearchDTOs { get; private set; }

        public UnitOfWork(EslDbContext context, ILogger<UnitOfWork> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Employees = new EmployeeRepository(_context, (ILogger<EmployeeRepository>)_logger);
            EmpRoles = new EmpRoleRepository(_context, (ILogger<EmpRoleRepository>)_logger);
            Constants = new ConstantRepository(_context, (ILogger<ConstantRepository>)_logger);
            Facilities = new FacilityRepository(_context, (ILogger<FacilityRepository>)_logger);
            LogTypes = new LogTypeRepository(_context, (ILogger<LogTypeRepository>)_logger);
            Meters = new MeterRepository(_context, (ILogger<MeterRepository>)_logger);
            AllEvents = new AllEventRepository(_context, (ILogger<AllEventRepository>)_logger);
            Subjects = new SubjectRepository(_context, (ILogger<SubjectRepository>)_logger);
            SearchDTOs = new SearchDTORepository(_context, (ILogger<SearchDTORepository>)_logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public Task SaveChangesAsync()
        {            
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
