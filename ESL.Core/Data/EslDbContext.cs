using ESL.Core.IConfiguration;
using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Data
{
    public partial class EslDbContext : DbContext, IEslDbContext
    {
        public EslDbContext(DbContextOptions<EslDbContext> options)
            : base(options)
        {

        }

        public DbSet<AllEvent> AllEvents { get; set; }

        public DbSet<ViewAlleventsCurrent> AlleventsCurrents { get; set; }

        public virtual DbSet<AllScadaUsersRole> Roles { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Constant> Constants { get; set; }

        public DbSet<LogType> LogTypes { get; set; }

        public DbSet<Meter> Meters { get; set; }

        #region Views

        public virtual DbSet<ViewAlleventsCurrent> ViewCurrentAllEvents { get; set; }

        public virtual DbSet<ViewAlleventsFacilNo> ViewAllEventsByFacility { get; set; }

        public virtual DbSet<ViewSearchAllevent> ViewSearchAllevents { get; set; }

        #endregion Views

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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EslDbContext).Assembly);  //ApplicationDbContext

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
            modelBuilder.Entity("ESL.Core.Models.BusinessEntities.ViewAllEventsCurrent",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_ALLEVENTS_CURRENT", "ESL");
                });

            modelBuilder.Entity("ESL.Core.Models.BusinessEntities.ViewAllEventsFacilNo",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_ALLEVENTS_FacilNOS", "ESL");
                    // b.Property(v => v.BlogName).HasColumnName("Name");
                });

            modelBuilder.Entity("ESL.Core.Models.BusinessEntities.ViewAllEventsLogType",
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
