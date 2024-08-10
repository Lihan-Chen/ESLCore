using ESL.Core.IConfiguration;
using ESL.Core.IRepositories;
using ESL.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace ESL.Core.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger _logger;

        // Add all IRepositories here
        public IUserRepository Users { get; private set; }
        public IEmployeeRepository Employees { get; private set; }

        public IMeterRepository Meters => throw new NotImplementedException();

        public IAllEventRepository AllEvents => throw new NotImplementedException();

        public IFacilityRepository Facilities => throw new NotImplementedException();

        public ILogTypeRepository LogTypes => throw new NotImplementedException();

        public IConstantRepository Constants => throw new NotImplementedException();

        public IClearanceIssueRepository ClearanceIssues => throw new NotImplementedException();

        public IClearanceTypeRepository ClearanceTypes => throw new NotImplementedException();

        public IClearanceZoneRepository ClearanceZones => throw new NotImplementedException();

        public IDetailsUserRepository DetailsList => throw new NotImplementedException();

        public IEOSRepository EOSLog => throw new NotImplementedException();

        public IEquipmentInvolvedRepository EquipmentInvolvedList => throw new NotImplementedException();

        public IFlowchangeRepository FlowChanges => throw new NotImplementedException();

        public IGeneralRepository GeneralLog => throw new NotImplementedException();

        public ILocationRepository Locations => throw new NotImplementedException();

        public IPlantShiftRepository PlantsShiftList => throw new NotImplementedException();

        public IRelatedToRepository RelatedToList => throw new NotImplementedException();

        public IScanDocRepository ScanDocs => throw new NotImplementedException();

        public IScanLobRepository ScanLobs => throw new NotImplementedException();

        public ISOCRepository SOClog => throw new NotImplementedException();

        public ISubjectRepository Subjects => throw new NotImplementedException();

        public IUnitRepository Units => throw new NotImplementedException();

        public IWorkOrderRepository WorkOrders => throw new NotImplementedException();

        public IWorkToBePerformedRepository WorkToBePerformedList => throw new NotImplementedException();

        //public IAllEventRepository AllEvents { get; private set; }
        //public IMeterRepository Meters { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logs");
            
            Users = new UserRepository(_context, _logger);
            Employees = new EmployeeRepository(_context, _logger);
            //AllEvents = new AllEventRepository(_context, _logger);
            //Meters = new MeterRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        { 
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //public async Task Dispose()
        //{
        //    await _context.DisposeAsync(); 
        //}





    }
}
