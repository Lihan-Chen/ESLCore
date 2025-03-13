using ESL.Core.IConfiguration;
using ESL.Core.IRepositories;
using ESL.Mvc.DataAccess.Persistence;
using ESL.Mvc.DataAccess.Repositories;

namespace ESL.Mvc.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EslDbContext _context;

        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(EslDbContext context, ILogger<UnitOfWork> logger, IEmployeeRepository employees, IEmpRoleRepositry empRoles, IConstantRepository constants, IFacilityRepository facilities, ILogTypeRepository logTypes, IMeterRepository meters, IAllEventRepository allEvents)
        {
            _context = context;
            _logger = logger;
            Employees = employees;
            EmpRoles = empRoles;
            Constants = constants;
            Facilities = facilities;
            LogTypes = logTypes;
            Meters = meters;
            AllEvents = allEvents;
        }

        public UnitOfWork(EslDbContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Add all IRepositories here
        //public IUserRepository Users { get; private set; }

        public IEmployeeRepository Employees { get; private set; }

        public IEmpRoleRepositry EmpRoles { get; private set; }

        public IConstantRepository Constants { get; private set; }

        public IFacilityRepository Facilities { get; private set; }

        public ILogTypeRepository LogTypes { get; private set; }

        public IMeterRepository Meters { get; private set; }

        public IAllEventRepository AllEvents { get; private set; }

        //public IClearanceIssueRepository ClearanceIssues => throw new NotImplementedException();

        //public IClearanceTypeRepository ClearanceTypes => throw new NotImplementedException();

        //public IClearanceZoneRepository ClearanceZones => throw new NotImplementedException();

        //public IDetailsUserRepository DetailsList => throw new NotImplementedException();

        //public IEOSRepository EOSLog => throw new NotImplementedException();

        //public IEquipmentInvolvedRepository EquipmentInvolvedList => throw new NotImplementedException();

        //public IFlowchangeRepository FlowChanges => throw new NotImplementedException();

        //public IGeneralRepository GeneralLog => throw new NotImplementedException();

        //public ILocationRepository Locations => throw new NotImplementedException();

        //public IPlantShiftRepository PlantsShiftList => throw new NotImplementedException();

        //public IRelatedToRepository RelatedToList => throw new NotImplementedException();

        //public IScanDocRepository ScanDocs => throw new NotImplementedException();

        //public IScanLobRepository ScanLobs => throw new NotImplementedException();

        //public ISOCRepository SOClog => throw new NotImplementedException();

        //public ISubjectRepository Subjects => throw new NotImplementedException();

        //public IUnitRepository Units => throw new NotImplementedException();

        //public IWorkOrderRepository WorkOrders => throw new NotImplementedException();

        //public IWorkToBePerformedRepository WorkToBePerformedList => throw new NotImplementedException();

        //public IAllEventRepository AllEvents { get; private set; }

        public ISubjectRepository Subjects { get; private set; }

        public UnitOfWork(
            EslDbContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = (ILogger<UnitOfWork>?)loggerFactory.CreateLogger("Logs");

            //Users = new UserRepository(_context, _logger);
            Employees = new EmployeeRepository(_context, (ILogger<EmployeeRepository>)_logger);

            Facilities = new FacilityRepository(_context, (ILogger<FacilityRepository>)_logger);

            AllEvents = new AllEventRepository(_context, (ILogger<AllEventRepository>)_logger);

            Meters = new MeterRepository(_context, (ILogger<MeterRepository>)_logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();

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

        //public async Task Dispose()
        //{
        //    await _context.DisposeAsync();
        //}





    }
}
