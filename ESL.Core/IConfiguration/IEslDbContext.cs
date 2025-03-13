using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.IConfiguration
{
    public interface IEslDbContext
    {
        
        public DbSet<AllEvent> AllEvents { get; set; }
        public DbSet<AllScadaUsersRole> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<Constant> Constants { get; set; }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Unit> Units { get; set; }
        // this seems not being used.
        // public DbSet<RealTime> RealTime { get; set; }

        // this is from the VIEW_REALTIME
        public DbSet<ViewRealTime> ViewRealtimes { get; set; }

        // this seems not being used.
        // public DbSet<ViewWorkOrder> ViewWorkOrders { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }

        public DbSet<WorkToBePerformed> WorkToBePerformeds { get; set; }


        #region Views

        public DbSet<AllEventCurrent> AllEventsCurrent { get; set; }

        public DbSet<AllEventFacil> AllEventFacils { get; set; }

        public DbSet<AllEventLogType> AllEventLogTypes { get; set; }

        public DbSet<AllEventRelatedTo> AllEventsRelatedTo { get; set; }

        public DbSet<AllEventSearch> AllEventsSearch { get; set; }

        public DbSet<ViewSearchAllevent> ViewAllEventsSearch { get; set; }

        #endregion Views

        public Task<int> SaveChangesAsync();
    }
}
