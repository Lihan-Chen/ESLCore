using Microsoft.EntityFrameworkCore;
using ESL.Core.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Extensions.Logging;
using ESL.Core.Models.BusinessEntities;


namespace ESL.Core.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // the dbset property will tell ef core that we have a table that needs to be created if it does not exist.

        public virtual DbSet<Facility> Facilities { get; set; }

        public virtual DbSet<LogType> LogTypes { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<AllEvent> AllEvents { get; set; }

        public virtual DbSet<Constant> Constants { get; set; }

        public virtual DbSet<ClearanceIssue> ClearanceIssues { get; set; }

        public virtual DbSet<ClearanceType> ClearanceTypes { get; set; }

        public virtual DbSet<ClearanceZone> ClearanceZones { get; set; }

        public virtual DbSet<Details> DetailsList { get; set; }

        public virtual DbSet<EOS> EOSLog { get; set; }

        public virtual DbSet<EquipmentInvolved> EquipmentInvolvedList { get; set; }

        public virtual DbSet<FlowChange> FlowChanges { get; set; }

        public virtual DbSet<GeneralLog> GeneralLog { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<PlantShift> PlantsShiftList { get; set; }

        public virtual DbSet<RelatedTo> RelatedToList { get; set; }

        public virtual DbSet<Meter> Meters { get; set; }

        public virtual DbSet<ScanDoc> ScanDocs { get; set; }

        public virtual DbSet<ScanLob> ScanLobs { get; set; }

        public virtual DbSet<SOC> SOClog { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<WorkOrder> WorkOrders { get; set; }

        public virtual DbSet<WorkToBePerformed> WorkToBePerformedList { get; set; }

        public virtual DbSet<ViewAlleventsCurrent> ViewCurrentAllEvents { get; set; }

        public virtual DbSet<ViewAlleventsFacilNo> ViewAllEventsByFacility { get; set; }

        public virtual DbSet<ViewAlleventsLogType> ViewAllEventsByLogType { get; set; }

        public virtual DbSet<ViewAlleventsRelatedTo> ViewRelatedAllevents {  get; set; }

        public virtual DbSet<ViewAlleventsSearch> ViewAlleventsSearches { get; set; }

        public virtual DbSet<ViewClearanceAll> ViewClearanceAll { get; set; }

        public virtual DbSet<ViewClearanceissue> ViewClearanceIssues { get; set; }
        
        public virtual DbSet<ViewClearanceIssuesCurrent> ViewCurrentClearanceIssues { get; set; }

        public virtual DbSet<ViewClearanceOutstanding> ViewOutstandingClearances { get; set; }

        public virtual DbSet<ViewClearanceType> ViewClearancesTypes { get; set; }

        public virtual DbSet<ViewEOSAll> ViewEOSAll {  get; set; }

        public virtual DbSet<ViewEOSCurrent> ViewCurrentEOS { get; set; }

        public virtual DbSet<ViewEOSOutstanding> ViewOutstandingEOS { get; set; }

        public virtual DbSet<ViewFlowchangeAll> ViewAllFlowChanges { get; set; }

        public virtual DbSet<ViewFlowchangePresched> ViewPreschedFlowChanges { get; set; }

        public virtual DbSet<ViewFlowchangesCurrent> ViewCurrentFlowChanges { get; set; }

        public virtual DbSet<ViewGeneralAll> ViewGeneralAll { get; set; }
        
        public virtual DbSet<ViewGeneralCurrent> ViewGeneralCurrent { get; set; }

        public virtual DbSet<ViewGeneralOutstanding> ViewOutstandingGeneral { get; set; }

        public virtual DbSet<ViewRealtime> ViewRealtime { get; set; }

        public virtual DbSet<ViewSearchAllevent> ViewSearchAllevents { get; set; }

        public virtual DbSet<ViewSOCAll> ViewAllSOC {  get; set; }

        public virtual DbSet<ViewSOCCurrent> ViewCurrentSOC { get; set; }

        public virtual DbSet<ViewSOCOutstanding> ViewOutstandingSOC { get; set; }

        public virtual DbSet<ViewWorkOrder> ViewWorkOrders { get; set; }

        //public virtual DbSet<View>


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(ApplicationDbContextHelpers.esl_connectionString);

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
                // You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
                // For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
                // Alternatively, using Microsoft.Extensions.Configuration to read appsettings.json into configurationBuilder, see the helper file
                //=> optionsBuilder.UseOracle(ApplicationDbContextHelpers.esl_connectionString);
                //options => options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.");

                // Enabling EF Core Logging https://dotnettutorials.net/lesson/crud-operations-in-entity-framework-core/
                // To Display the Generated Database Script https://learn.microsoft.com/en-us/ef/core/logging-events-diagnostics/simple-logging
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);  // To Debug Window: message => Debug.WriteLine(message) // To File see example ref link above

                // optionsBuilder.UseOracle("Data Source=ODev41.world;Persist Security Info=false;User ID=ESL;Password=MWDesl01_#;");

                //optionsBuilder.UseSqlite(ApplicationDbContextHelpers.sqlite_connectionString);
                //}
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ref:desenvolvedor-io/dev-store/CatalogContext.cs

            //modelBuilder.Ignore<ValidationResult>();
            //modelBuilder.Ignore<Event>();

            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            //    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //    property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // ref: m-jovanovic/rally-simulator/RallySimulatorDbCotext.cs
            // modelBuilder.ApplyUtcDateTimeConverter();

            //base.OnModelCreating(modelBuilder);

            //Oracle Schema
            modelBuilder
            .HasDefaultSchema("ESL")
            .UseCollation("USING_NLS_COMP");

            #region Views
            // Mapping to view instead of table with schema as the second parameter

            //AllEvent
            // For AllEvents/Index? (To be verified)
            modelBuilder.Entity("ESL.Core.Models.ViewAllEventsCurrent",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_ALLEVENTS_CURRENT", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewAllEventsFacilNo",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_ALLEVENTS_FacilNoS", "ESL");
                    // b.Property(v => v.BlogName).HasColumnName("Name");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewAllEventsLogType",
           b =>
            {
                b.HasNoKey();
                b.ToView("VIEW_ALLEVENTS_LOGTYPE", "ESL");
            });

            modelBuilder.Entity("ESL.Core.Models.ViewAllEventsRelatedTo",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_ALLEVENTS_RelatedTo", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewAllEventsSearch",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_ALLEVENTS_SEARCH", "ESL");
                    // b.Property(v => v.BlogName).HasColumnName("Name");
                });
            
            // Clearance
            modelBuilder.Entity("ESL.Core.Models.ViewAClearanceAll",
            b =>
            {
                b.HasNoKey();
                b.ToView("VIEW_CLEARANCE_ALL", "ESL");
            });

            modelBuilder.Entity("ESL.Core.Models.ViewClearanceissue",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_CLEARANCEISSUES", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewClearanceissuesCurrent",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_CLEARANCEISSUES_CURRENT", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewClearanceissuesOutstanding",
                            b =>
                            {
                                b.HasNoKey();
                                b.ToView("VIEW_CLEARANCEISSUES_OUTSTANDING", "ESL");
                            });

            modelBuilder.Entity("ESL.Core.Models.ViewClearanceType",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_CLEARANCE_TYPES", "ESL");
                    // b.Property(v => v.BlogName).HasColumnName("Name");
                });
            
            // EOS
            modelBuilder.Entity("ESL.Core.Models.ViewEosAlL",
            b =>
            {
                b.HasNoKey();
                b.ToView("VIEW_EOS_ALL", "ESL");
            });

            modelBuilder.Entity("ESL.Core.Models.ViewEosCurrent",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_EOS_CURRENT", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewEosOutstanding",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_EOS_OUTSTANDING", "ESL");
                });

            //Flowchange
            modelBuilder.Entity("ESL.Core.Models.ViewFlowchangeAlL",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_FLOWCHANGE_ALL", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewFlowchangePresched",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_FLOWCHANGE_PRESCHED", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewFlowchangesCurrent",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_FLOWCHANGES_CURRENT", "ESL");
                });

            // General
            modelBuilder.Entity("ESL.Core.Models.ViewGeneralAlL",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_GENERAL_ALL", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewGeneralCurrent",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_GENERAL_CURRENT", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewGeneralOutstanding",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_GENERAL_OUTSTANDING", "ESL");
                });

            // Realtime
            modelBuilder.Entity("ESL.Core.Models.ViewRealtime",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_REALTIME", "ESL");
                });

            // Search AllEvents
            modelBuilder.Entity("ESL.Core.Models.ViewSearchAllevent",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_SEARCH_ALLEVENTS", "ESL");
                });

            // SOC
            modelBuilder.Entity("ESL.Core.Models.ViewSocAll",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_SOC_ALL", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewSocCurrent",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_SOC_CURREMT", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.ViewSocOutstanding",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_SOC_OUTSTANDING", "ESL");
                });

            // Work Orders
            modelBuilder.Entity("ESL.Core.Models.ViewWorkorder",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_WorkOrders", "ESL");
                });

            #endregion

            modelBuilder.HasSequence("PLSQL_PROFILER_RUNNUMBER");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        // for Views
        // https://stackoverflow.com/questions/36012616/working-with-sql-views-in-entity-framework-core
        // AuthorArticleCounts
        // SELECT a.AuthorName, Count(r.ArticleId) as ArticleCount
        // from Authors a
        //  JOIN Articles r on r.AuthorId = a.AuthorId
        // GROUP BY a.AuthorName

        // public class AuthorArticleCount
        // {
        //    public string AuthorName { get; private set; }
        //    public int ArticleCount { get; private set; }
        // }

        // public DbQuery<AuthorArticleCount> AuthorArticleCounts{get;set;}

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //    modelBuilder.Query<AuthorArticleCount>().ToView("AuthorArticleCount");
        // }

        // var results=_context.AuthorArticleCounts.ToList();

        // models

        //modelBuilder.Entity<AllEvent>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo });

        //    entity.Table("ESL_AllEvents");

        //    entity.Property(e => e.EventID).HasColumnName("EventID");
        //    entity.Property(e => e.EventID_RevNo).HasColumnName("EventID_RevNo");
        //    entity.Property(e => e.ClearanceID).HasColumnName("ClearanceID");
        //});

        //modelBuilder.Entity<ClearanceType>(entity =>
        //{
        //    entity.HasKey(e => e.ClearanceTypeNo);

        //    entity.Table("ESL_ClearanceTypes");
        //});

        //modelBuilder.Entity<ClearanceZone>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilType, e.ZoneNo });

        //    entity.Table("ESL_ClearanceZones");
        //});

        //modelBuilder.Entity<Constant>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.ConstantName, e.StartDate });

        //    entity.Table("ESL_Constants");
        //});

        //modelBuilder.Entity<Details>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.DetailsNo });

        //    entity.Table("ESL_Details");

        //    entity.HasIndex(e => new { e.SubjectFacilNo, e.SubjectNo }, "IX__Details_SubjectFacilNo_SubjectNo");

        //    entity.HasOne(d => d.Subject).WithMany(p => p.Details).HasForeignKey(d => new { d.SubjectFacilNo, d.SubjectNo });
        //});

        //modelBuilder.Entity<Employee>(entity =>
        //{
        //    entity.HasKey(e => e.EmployeeNo);

        //    entity.Table("ESL_Employees");

        //    entity.HasIndex(e => e.FacilityFacilNo, "IX__Employees_FacilityFacilNo");

        //    // entity.HasOne(d => d.FacilityFacilNoNavigation).WithMany(p => p.Employees).HasForeignKey(d => d.FacilityFacilNo);
        //});

        //modelBuilder.Entity<EquipmentInvolved>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.EquipNo });

        //    entity.Table("ESL_EquipmentInvolved");
        //});

        //modelBuilder.Entity<Facility>(entity =>
        //{
        //    entity.HasKey(e => e.FacilNo);

        //    entity.Table("ESL_Facilities");
        //});

        //modelBuilder.Entity<LogType>(entity =>
        //{
        //    entity.HasKey(e => e.LogTypeNo);

        //    entity.Table("ESL_LogTypes");
        //});

        //modelBuilder.Entity<Meter>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.MeterID });

        //    entity.Table("ESL_Meters");

        //    entity.Property(e => e.MeterID).HasColumnName("MeterID");
        //});

        //modelBuilder.Entity<RelatedTo>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.RelatedToSubject });

        //    entity.Table("ESL_RelatedTo");

        //    entity.Property(e => e.EventID).HasColumnName("EventID");
        //    entity.Property(e => e.RelatedToSubject).HasColumnName("RelatedTo_Subject");
        //});

        //modelBuilder.Entity<Subject>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.SubjNo });

        //    entity.Table("ESL_Subjects");
        //});

        //modelBuilder.Entity<Unit>(entity =>
        //{
        //    entity.HasKey(e => e.UnitNo);

        //    entity.Table("ESL_Units");
        //});

        //modelBuilder.Entity<WorkOrder>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.WoNo });

        //    entity.Table("ESL_WorkOrders");

        //    entity.Property(e => e.EventID).HasColumnName("EventID");
        //    entity.Property(e => e.WoNo).HasColumnName("WO_No");
        //});

        //modelBuilder.Entity<WorkToBePerformed>(entity =>
        //{
        //    entity.HasKey(e => e.WorkNo);

        //    entity.Table("ESL_WorkToBePerformed");
        //});

        //modelBuilder.Entity<PlantsShiftList>(entity =>
        //{
        //    entity.HasKey(e => new { e.FacilNo, e.ShiftNo });

        //    entity.Table("ESLPlantsShiftList");
        //});

        // OnModelCreatingPartial(modelBuilder);

        // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

//// On model creating function will provide us with the ability to manage the tables properties
//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    base.OnModelCreating(modelBuilder);

//    modelBuilder.Entity("ESL.Core.Models.AllEvent", b =>
//    {
//        b.Property<int>("FacilNo")
//            .HasColumnType("INTEGER");

//        b.Property<int>("LogTypeNo")
//            .HasColumnType("INTEGER");

//        b.Property<string>("EventID")
//            .HasColumnType("TEXT");

//        b.Property<int>("EventID_RevNo")
//            .HasColumnType("INTEGER");

//        b.Property<string>("ClearanceID")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("Details")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<DateTime?>("EventDate")
//            .HasColumnType("TEXT");

//        b.Property<string>("EventTime")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("FacilAbbr")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("FacilName")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("LogTypeName")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("ModifyFlag")
//            .HasColumnType("TEXT");

//        b.Property<string>("Notes")
//            .HasColumnType("TEXT");

//        b.Property<string>("OperatorType")
//            .HasColumnType("TEXT");

//        b.Property<int>("ScanDocsNo")
//            .HasColumnType("INTEGER");

//        b.Property<string>("Subject")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("UpdateDate")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("UpdatedBy")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.HasKey("FacilNo", "LogTypeNo", "EventID", "EventID_RevNo");

//        b.ToTable("AllEvents");
//    });

//    modelBuilder.Entity("ESL.Core.Models.Employee", b =>
//    {
//        b.Property<int>("Id")
//            .ValueGeneratedOnAdd()
//            .HasColumnType("INTEGER")
//            .HasColumnName("EmployeeNo");

//        b.Property<string>("Company")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("Disable")
//            .HasColumnType("TEXT");

//        b.Property<int?>("FacilNo")
//            .HasColumnType("INTEGER");

//        b.Property<string>("FirstName")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("GroupName")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("JobTitle")
//            .HasColumnType("TEXT");

//        b.Property<string>("LastName")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("Notes")
//            .HasColumnType("TEXT");

//        b.Property<DateTimeOffset>("UpdateDate")
//            .HasColumnType("TEXT");

//        b.Property<string>("UpdatedBy")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.HasKey("Id");

//        b.ToTable("Employees");
//    });

//    modelBuilder.Entity("ESL.Core.Models.Meter", b =>
//    {
//        b.Property<string>("MeterID")
//            .HasColumnType("TEXT");

//        b.Property<string>("Disable")
//            .HasColumnType("TEXT");

//        b.Property<int>("FacilNo")
//            .HasColumnType("INTEGER");

//        b.Property<string>("MeterType")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("Notes")
//            .HasColumnType("TEXT");

//        b.Property<int?>("SortNo")
//            .HasColumnType("INTEGER");

//        b.Property<DateTime?>("UpdateDate")
//            .HasColumnType("TEXT");

//        b.Property<string>("UpdatedBy")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.HasKey("MeterID");

//        b.ToTable("Meters");
//    });

//    modelBuilder.Entity("ESL.Core.Models.User", b =>
//    {
//        b.Property<int>("Id")
//            .ValueGeneratedOnAdd()
//            .HasColumnType("TEXT");

//        b.Property<string>("Email")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("FirstName")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.Property<string>("LastName")
//            .IsRequired()
//            .HasColumnType("TEXT");

//        b.HasKey("Id");

//        b.ToTable("Users");
//    });
//}

