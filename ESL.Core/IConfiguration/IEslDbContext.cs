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
        
        DbSet<AllEvent> AllEvents { get; set; }
        DbSet<AllScadaUsersRole> Roles { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Facility> Facilities { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        DbSet<Constant> Constants { get; set; }
        DbSet<Meter> Meters { get; set; }

        #region Views

        DbSet<AllEventCurrent> AllEventsCurrent { get; set; }

        DbSet<AllEventFacil> AllEventFacils { get; set; }

        DbSet<AllEventSearch> AllEventsSearch { get; set; }

        #endregion Views
    }
}
