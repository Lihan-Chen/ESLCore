using ESL.Core.Models.BusinessEntities;
using ESL.Application.Models;
using ESL.Infrastructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ESL.Infrastructure.DataAccess
{
    public partial class EslDbContext : DbContext
    {
        public EslDbContext()
        {
        }

        public EslDbContext(DbContextOptions<EslDbContext> options)
            : base(options)
        {
        }


        //DbSets from Oracle Tables have NO "_" in their names
        public virtual DbSet<AllEvent> AllEvents { get; set; }

        public virtual DbSet<CalloutType> CalloutTypes { get; set; }

        public virtual DbSet<ClearanceIssue> ClearanceIssueLog { get; set; }

        public virtual DbSet<ClearanceType> ClearanceTypes { get; set; }

        public virtual DbSet<ClearanceZone> ClearanceZones { get; set; }

        //// To avoid ambuigity, Constant is renamed to EslConstant
        public virtual DbSet<EslConstant> EslContants { get; set; }

        public virtual DbSet<Detail> Details { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EOS> EOSLog { get; set; }

        public virtual DbSet<Equipment> EquipmentInvolved { get; set; }

        public virtual DbSet<Facility> Facilities { get; set; }

        public virtual DbSet<FlowChange> FlowChangeLog { get; set; }

        public virtual DbSet<General> GeneralLog { get; set; }

        //public virtual DbSet<LogStatus> LogStatus { get; set; }

        public virtual DbSet<LogTable> LogTables { get; set; }

        public virtual DbSet<LogType> LogTypes { get; set; }

        public virtual DbSet<Meter> Meters { get; set; }

        public virtual DbSet<PlantShift> PlantShifts { get; set; }

        public virtual DbSet<RelatedTo> RelatedEvents { get; set; }

        public virtual DbSet<Rpt> RptAllEvents { get; set; }

        public virtual DbSet<ScanDoc> ScanDocs { get; set; }

        public virtual DbSet<ScanLob> ScanLobs { get; set; }

        public virtual DbSet<SOC> SOCLog { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<WorkOrder> WorkOrders { get; set; }

        public virtual DbSet<WorkTBP> WorkTBPList { get; set; }

        // DbSets from Oracle Views have "_" in their names

        // Deprecated but keep the Oracle table for future use
        //public virtual DbSet<ESL_USER_INFO_VW> User_Info_VW { get; set; }

        public virtual DbSet<Current_AllEvent> Current_AllEvents { get; set; } // VIEW_ALLEVENTS_CURRENT
        //public virtual DbSet<AllEvent_Current> Current_AllEvents { get; set; } // VIEW_ALLEVENTS_CURRENT

        //public virtual DbSet<VIEW_ALLEVENTS_FACILNO> AllEvent_FacilNos { get; set; }

        //public virtual DbSet<VIEW_ALLEVENTS_LOGTYPE> AllEvent_LogTypes { get; set; }

        //public virtual DbSet<VIEW_ALLEVENTS_RELATEDTO> AllEvent_RelatedTos { get; set; }

        //public virtual DbSet<VIEW_ALLEVENTS_SEARCH> AllEvent_Searches { get; set; }

        public virtual DbSet<VIEW_CLEARANCEISSUE> ClearanceIssues { get; set; }

        //public virtual DbSet<VIEW_CLEARANCEISSUES_CURRENT> Current_ClearanceIssues { get; set; }

        //public virtual DbSet<VIEW_CLEARANCETYPE> Clearance_Types { get; set; }

        //public virtual DbSet<VIEW_CLEARANCE_ALL> All_Clearances { get; set; }

        //public virtual DbSet<VIEW_CLEARANCE_OUTSTANDING> Outstanding_Clearances { get; set; }

        //public virtual DbSet<VIEW_EOS_ALL> All_EOS { get; set; }

        //public virtual DbSet<VIEW_EOS_CURRENT> Current_EOS { get; set; }

        //public virtual DbSet<VIEW_EOS_OUTSTANDING> Outstanding_EOS { get; set; }

        public virtual DbSet<VIEW_FLOWCHANGES_CURRENT> Current_FlowChanges { get; set; }

        //public virtual DbSet<VIEW_FLOWCHANGE_ALL> All_FlowChanges { get; set; }

        //public virtual DbSet<VIEW_FLOWCHANGE_PRESCHED> Presched_FlowChanges { get; set; }

        //public virtual DbSet<VIEW_GENERAL_ALL> All_Generals { get; set; }

        public virtual DbSet<VIEW_GENERAL_CURRENT> Current_Generals { get; set; }

        public virtual DbSet<Outstanding_General> Outstanding_Generals { get; set; }

        //public virtual DbSet<VIEW_REALTIME> Realtime_FlowChanges { get; set; }

        //public virtual DbSet<VIEW_SEARCH_ALLEVENT> VIEW_SEARCH_ALLEVENTs { get; set; }

        public virtual DbSet<AllEvent_Search> AllEvent_Searches { get; set; }

        //public virtual DbSet<VIEW_SOC_ALL> All_SOC { get; set; }

        //public virtual DbSet<VIEW_SOC_CURRENT> Current_SOC { get; set; }

        //public virtual DbSet<VIEW_SOC_OUTSTANDING> Outstanding_SOC { get; set; }

        //public virtual DbSet<VIEW_WORKORDER> Work_Orders { get; set; }

        // see program.cs for AddDbContext
        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseOracle("Data Source=odev41.world;Persist Security Info=false;User ID=ESL;Password=MWDesl01_#;",
        //                                    optionBuilder => optionBuilder.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion23)) // sqlServerOptionBuilder => sqlServerOptionBuilder.EnableRetryOnFailure() from https://www.youtube.com/watch?v=NPgFlqXPbK8              
        //                        .LogTo(Console.WriteLine, LogLevel.Information)
        //                         .EnableSensitiveDataLogging(); 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // From ESLCore.Api
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EslDbContext).Assembly);

            modelBuilder
                .HasDefaultSchema("ESL")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.ApplyConfiguration(new AllEventEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CalloutTypeEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new UserRoleEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ClearanceIssueEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ClearanceTypeEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ClearanceZoneEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new EslConstantEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new DetailEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new EOSEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new EquipmentEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new FacilityEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new FlowChangeEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new GeneralEntityTypeConfiguration());

            //modelBuilder.ApplyConfiguration(new LogStatusEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new LogTableEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new LogTypeEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new MeterEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PlantShiftEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new RelatedToEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new RptEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ScanDocEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ScanLobEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new SOCEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new SubjectEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new UnitEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new WorkOrderEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new WorkTBPEntityTypeConfiguration());

            // Views below

            // Deprecated due to Pro2
            //modelBuilder.ApplyConfiguration(new ESL_USER_INFO_VWEntityTypeConfiguration());

            //modelBuilder.Entity<AllEvent>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_ALLEVENTS_PK");
            //    // already defined in model attribute [Index("UpdateDate", AllDescending = false, IsUnique = false, Name = "UPDATEDATE")]
            //    // entity.HasIndex(e => e.UpdateDate, "UPDATEDATE");
            //});

            //modelBuilder.Entity<CalloutType>(entity =>
            //{
            //    entity.HasKey(e => e.CalloutTypeNo).HasName("ESL_CALLOUTTYPES_PK");
            //});

            //modelBuilder.Entity<ClearanceIssue>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_CLEARANCEISSUES_PK");
            //});

            //modelBuilder.Entity<ClearanceType>(entity =>
            //{
            //    entity.HasKey(e => e.ClearanceTypeNo).HasName("ESL_CLEARANCETYPES_PK");
            //});

            //modelBuilder.Entity<ClearanceZone>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilType, e.ZoneNo }).HasName("ESL_CLEARANCEZONES_PK");
            //});

            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    entity.HasKey(e => e.EmployeeNo).HasName("EMPLOYEES_PK");

            //    entity.Property(e => e.EmployeeNo).ValueGeneratedNever();
            //});

            //modelBuilder.Entity<EOS>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_EOS_PK");
            //});

            ////modelBuilder.Entity<Equipment>(entity =>
            ////{
            ////    entity.HasKey(e => new { e.FacilNo, e.EquipNo }).HasName("ESL_EQUIPMENTINVOLVED_PK");
            ////});

            //modelBuilder.Entity<FlowChange>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_FLOWCHANGES_PK");
            //});

            //modelBuilder.Entity<General>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_GENERAL_PK");
            //});

            //modelBuilder.Entity<LogStatus>(entity =>
            //{
            //    entity.HasKey(e => e.LogStatusNo).HasName("ESL_LOGSTATUS_PK");
            //});

            //modelBuilder.Entity<LogTable>(entity =>
            //{
            //    entity.HasKey(e => e.LogTypeNo).HasName("ESL_LOGNAMES_PK");
            //});

            //modelBuilder.Entity<LogType>(entity =>
            //{
            //    entity.HasKey(e => e.LogTypeNo).HasName("ESL_LOGTYPES_PK");
            //});

            //modelBuilder.Entity<Meter>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilNo, e.MeterID }).HasName("ESL_METERS_PK");
            //});

            //modelBuilder.Entity<PlantShift>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilNo, e.ShiftNo }).HasName("PLANTSHIFT_PK");
            //});

            //modelBuilder.Entity<ScanLob>(entity =>
            //{
            //    entity.HasKey(e => e.ScanSeqNo).HasName("ESL_SCANLOBS_PK");

            //    entity.Property(e => e.ScanBlob).HasDefaultValueSql("EMPTY_BLOB()");
            //});

            //modelBuilder.Entity<SOC>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_SOC_PK");
            //});

            //modelBuilder.Entity<Subject>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilNo, e.SubjNo }).HasName("ESL_SUBJECTS_PK");
            //});

            //modelBuilder.Entity<UserRole>(entity =>
            //{
            //    entity
            //        .HasNoKey()
            //        .ToTable("ESL_ALLSCADAUSERS_ROLE");
            //});

            //modelBuilder.Entity<WorkTBP>(entity =>
            //{
            //    entity.HasKey(e => new { e.FacilType, e.WorkNo }).HasName("WORKTOBEPERFORMED_PK");
            //});

            // Views below

            //modelBuilder.Entity<ESL_USER_INFO_VW>(entity =>
            //{
            //    entity.HasNoKey().ToView("ESL_USER_INFO_VW");
            //});

            // testing modelBuilder
            modelBuilder.Entity<Current_AllEvent>(entity =>
            {
                entity.HasNoKey().ToView("VIEW_ALLEVENTS_CURRENT");
            });

            //modelBuilder.Entity<VIEW_ALLEVENTS_CURRENT>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_ALLEVENTS_CURRENT");
            //});

            //modelBuilder.Entity<VIEW_ALLEVENTS_FACILNO>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_ALLEVENTS_FACILNOS");
            //});

            //modelBuilder.Entity<VIEW_ALLEVENTS_LOGTYPE>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_ALLEVENTS_LOGTYPES");
            //});

            //modelBuilder.Entity<VIEW_ALLEVENTS_RELATEDTO>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_ALLEVENTS_RELATEDTO");
            //});

            //modelBuilder.Entity<VIEW_ALLEVENTS_SEARCH>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_ALLEVENTS_SEARCH");
            //});

            modelBuilder.Entity("AllEvent_Search",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_ALLEVENTS_SEARCH", "ESL");
                });

            modelBuilder.Entity<VIEW_CLEARANCEISSUE>(entity =>
            {
                entity.HasNoKey().ToView("VIEW_CLEARANCEISSUES");
            });

            //modelBuilder.Entity<VIEW_CLEARANCEISSUES_CURRENT>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_CLEARANCEISSUES_CURRENT");
            //});

            //modelBuilder.Entity<VIEW_CLEARANCETYPE>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_CLEARANCETYPES");
            //});

            //modelBuilder.Entity<VIEW_CLEARANCE_ALL>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_CLEARANCE_ALL");
            //});

            //modelBuilder.Entity<VIEW_CLEARANCE_OUTSTANDING>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_CLEARANCE_OUTSTANDING");
            //});

            //modelBuilder.Entity<VIEW_EOS_ALL>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_EOS_ALL");
            //});

            //modelBuilder.Entity<VIEW_EOS_CURRENT>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_EOS_CURRENT");
            //});

            //modelBuilder.Entity<VIEW_EOS_OUTSTANDING>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_EOS_OUTSTANDING");
            //});

            modelBuilder.Entity<VIEW_FLOWCHANGES_CURRENT>(entity =>
            {
                entity.HasNoKey().ToView("VIEW_FLOWCHANGES_CURRENT");
            });

            //modelBuilder.Entity<VIEW_FLOWCHANGE_ALL>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_FLOWCHANGE_ALL");
            //});

            //modelBuilder.Entity<VIEW_FLOWCHANGE_PRESCHED>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_FLOWCHANGE_PRESCHED");
            //});

            //modelBuilder.Entity<VIEW_GENERAL_ALL>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_GENERAL_ALL");
            //});

            //modelBuilder.Entity<VIEW_GENERAL_CURRENT>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_GENERAL_CURRENT");
            //});

            modelBuilder.Entity<Outstanding_General>(entity =>
            {
                entity.HasNoKey().ToView("VIEW_GENERAL_OUTSTANDING");

                entity.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasPrecision(2);

                entity.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasPrecision(2);

                entity.Property(e => e.EventID)
                .HasColumnName("EVENTID").HasColumnType("VARCHAR2(20)");

                entity.Property(e => e.EventID_RevNo)
                .HasColumnName("EVENTID_REVNO").HasPrecision(2);

                entity.Property(e => e.EventDate)
                .HasColumnName("EVENTDATE").HasColumnType("DATE");

                entity.Property(e => e.EventTime)
                .HasColumnName("EVENTTIME").HasColumnType("VARCHAR2(5)");
            });

            //modelBuilder.Entity<VIEW_REALTIME>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_REALTIME");
            //});

            //modelBuilder.Entity<VIEW_SEARCH_ALLEVENT>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_SEARCH_ALLEVENTS");
            //});

            //modelBuilder.Entity<VIEW_SOC_ALL>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_SOC_ALL");
            //});

            //modelBuilder.Entity<VIEW_SOC_CURRENT>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_SOC_CURRENT");
            //});

            //modelBuilder.Entity<VIEW_SOC_OUTSTANDING>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_SOC_OUTSTANDING");
            //});

            //modelBuilder.Entity<VIEW_WORKORDER>(entity =>
            //{
            //    entity.HasNoKey().ToView("VIEW_WORKORDERS");
            //});

            //modelBuilder.HasSequence("PLSQL_PROFILER_RUNNUMBER");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        // To configure globally for string to be non-unicode (ie. ASCII only)
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // https://davecallan.com/make-strings-non-unicode-entity-framework-code-first/
            configurationBuilder.Properties<string>().AreUnicode(false);
            base.ConfigureConventions(configurationBuilder);
        }

        // This should be in the IEslDbContext
        //public interface IApplicationDbContext
        //{
        //    DbSet<User> Users { get; }
        //    DbSet<TodoItem> TodoItems { get; }

        //    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        //}

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // When should you publish domain events?
            //
            // 1. BEFORE calling SaveChangesAsync
            //     - domain events are part of the same transaction
            //     - immediate consistency
            // 2. AFTER calling SaveChangesAsync
            //     - domain events are a separate transaction
            //     - eventual consistency
            //     - handlers can fail

            int result = await base.SaveChangesAsync(cancellationToken);

            // await PublishDomainEventsAsync();

            return result;
        }

        //private async Task PublishDomainEventsAsync()
        //{
        //    var domainEvents = ChangeTracker
        //        .Entries<Entity>()
        //        .Select(entry => entry.Entity)
        //        .SelectMany(entity =>
        //        {
        //            List<IDomainEvent> domainEvents = entity.DomainEvents;

        //            entity.ClearDomainEvents();

        //            return domainEvents;
        //        })
        //        .ToList();

        //    foreach (IDomainEvent domainEvent in domainEvents)
        //    {
        //        await publisher.Publish(domainEvent);
        //    }
        //}
    }
}
