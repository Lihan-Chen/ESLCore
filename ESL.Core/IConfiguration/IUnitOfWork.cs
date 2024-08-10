using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESL.Core.IRepositories;
using ESL.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ESL.Core.IConfiguration
{
    internal interface IUnitOfWork
    {
        // Add all IRepositories here
        IUserRepository Users { get; }

        IEmployeeRepository Employees { get; }

        IMeterRepository Meters { get; }

        IAllEventRepository AllEvents { get; }

        IFacilityRepository Facilities { get; }

        ILogTypeRepository LogTypes { get; }

        IConstantRepository Constants { get; }

        IClearanceIssueRepository ClearanceIssues { get; }

        IClearanceTypeRepository ClearanceTypes { get; }

        IClearanceZoneRepository ClearanceZones { get; }

        IDetailsUserRepository DetailsList { get; }

        IEOSRepository EOSLog { get; }

        IEquipmentInvolvedRepository EquipmentInvolvedList { get; }

        IFlowchangeRepository FlowChanges { get; }

        IGeneralRepository GeneralLog { get; }

        ILocationRepository Locations { get; }

        IPlantShiftRepository PlantsShiftList { get; }

        IRelatedToRepository RelatedToList { get; }

        IScanDocRepository ScanDocs { get; }

        IScanLobRepository ScanLobs { get; }

        ISOCRepository SOClog { get; }

        ISubjectRepository Subjects { get; }

        IUnitRepository Units { get; }

        IWorkOrderRepository WorkOrders { get; }

        IWorkToBePerformedRepository WorkToBePerformedList { get; }







        Task CompleteAsync();
    }

}

