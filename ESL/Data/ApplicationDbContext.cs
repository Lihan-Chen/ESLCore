using ESL.API.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using System.Reflection.Metadata;

namespace ESL.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        //public DbSet<Facility> Facilities { get; set; }
        //public DbSet<AllEvent> AllEvents { get; set; }
        //public DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Facility> Facilities { get; set; }

        public virtual DbSet<LogType> LogTypes { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<ESL.Core.Models.Constant> Constants { get; set; }

        public virtual DbSet<AllEvent> AllEvents { get; set; }

        public virtual DbSet<ClearanceIssue> ClearanceIssues { get; set; }

        public virtual DbSet<ClearanceType> ClearanceTypes { get; set; }

        public virtual DbSet<ClearanceZone> ClearanceZones { get; set; }

        public virtual DbSet<Details> DetailsList { get; set; }

        public virtual DbSet<EOS> EOSLog { get; set; }

        //public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<EquipmentInvolved> EquipmentInvolvedList { get; set; }

        public virtual DbSet<FlowChange> FlowChanges { get; set; }

        public virtual DbSet<GeneralLog> GeneralLog { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<PlantShift> PlantsShiftList { get; set; }

        public virtual DbSet<RelatedTo> RelatedToList { get; set; }

        public virtual DbSet<Meter> Meters { get; set; }

        public virtual DbSet<SOC> SOClog { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<WorkOrder> WorkOrders { get; set; }

        public virtual DbSet<WorkToBePerformed> WorkToBePerformedList { get; set; }

    }
}
