using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using ESL.Api.Models.BusinessEntities;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

namespace ESL.Api.Models.DAL
{
    public class ApplicationDbContext : DbContext
    {
        //static LoggerFactory object https://www.entityframeworktutorial.net/efcore/logging-in-entityframework-core.aspx
        //public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
        //      new ConsoleLoggerProvider((_, __) => true, true)
        //});

        // or,
        // public static readonly ILoggerFactory loggerFactory = new LoggerFactory().AddConsole((_, ___) => true);

        //Constructor calling the Base DbContext Class Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
            
        }

        public virtual DbSet<ViewAlleventsCurrent> ViewAlleventsCurrents { get; set; }

        public DbSet<ViewAlleventsLogType> AlleventLogTypes { get; set; }

        public DbSet<Details> DetailsList { get; set; }

        // public virtual DbSet<AllEvent> AllEvents {  get; set; }  

        // public virtual DbSet<AllScadaUsersRole> AllScadaUsersRoles { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Facility> Facilities { get; set; }

        public virtual DbSet<FlowChange> FlowChanges { get; set; }

        // public virtual DbSet<LogType> LogTypes { get; set; }

        public virtual DbSet<BusinessEntities.Meter> Meters { get; set; }

        public virtual DbSet<MeterReading> MetersReadings { get; set; }

        public DbSet<MeterReadingSP> MeterReadingSPs { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        // public virtual DbSet<UserSession> UsersSessions { get; set; }

        public virtual DbSet<WO> WO { get; set; }

        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseOracle("Data Source=ODev41.world;Persist Security Info=false;User ID=ESL;Password=MWDesl01_#;"); //?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.");
        {
            //    //use this to configure the contex's Connection String
            //    optionsBuilder.UseOracle(@"user id=esl;password=MWDesl01_#;data source=dev7.world;Persist Security Info=false;Min Pool Size=10;Connection Lifetime=120;");
            //    b => b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion21));  -- this is for Json column (owned property)
            //    https://github.com/oracle/dotnet-db-samples/blob/master/samples/ef-core/json/json-columns.cs
            //    .UseLoggerFactory(_myLoggerFactory);  -- https://docs.oracle.com/en/database/oracle/oracle-data-access-components/19.3/odpnt/EFCoreLogging.html#GUID-965B78C4-8E96-44E8-A3DC-151D38546845
        }

        //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use this to configure the model

            base.OnModelCreating(modelBuilder);

            //modelBuilder
            //.HasDefaultSchema("ESL")
            //.UseCollation("USING_NLS_COMP");

            #region Views
            // Mapping to view instead of table with schema as the second parameter

            //AllEvent
            // For AllEvents/Index? (To be verified)
            modelBuilder.Entity<ViewAlleventsCurrent>( //"ESL.Core.Models.ViewAllEventsCurrent",
                b =>
                {
                    b.HasNoKey();
                    b.ToView("VIEW_ALLEVENTS_CURRENT", schema: "ESL");
                });

            modelBuilder
                .Entity<ViewAlleventsLogType>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("VIEW_ALLEVENTS_LOGTYPES", schema: "ESL");
                });

            modelBuilder
                .Entity<MeterReadingSP>(entity =>
                {
                    entity.HasNoKey();

                    entity.Property(e => e.MeterID)
                      .HasColumnName("METERID");

                    entity.Property(e => e.NewValue)
                   .HasColumnName("NEWVALUE");

                    entity.Property(e => e.Unit)
                   .HasColumnName("UNIT");

                    entity.Property(e => e.EventDate)
                    .HasColumnName("EVENTDATE");
                    //.HasConversion(val => val.ToShortDateString(), val => DateTime.Parse(val));

                    entity.Property(e => e.EventTime)
                   .HasColumnName("EVENTTIME");

                    entity.Property(e => e.UpdateDate)
                   .HasColumnName("UPDATEDATE");

                    entity.Property(e => e.EventID_RevNo)
                   .HasColumnName("EVENTID_REVNO");
                });

            modelBuilder.Entity<MeterReading>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MeterID)
                  .HasColumnName("METERID");

                entity.Property(e => e.Value)
               .HasColumnName("NEWVALUE");

                entity.Property(e => e.Unit)
               .HasColumnName("UNIT");

                entity.Property(e => e.EventDate)
                .HasColumnName("EVENTDATE");
                //.HasConversion(val => val.ToShortDateString(), val => DateTime.Parse(val));

                entity.Property(e => e.EventTime)
               .HasColumnName("EVENTTIME");

                entity.Property(e => e.UpdateDate)
               .HasColumnName("UPDATEDATE");

                entity.Property(e => e.EventID_RevNo)
               .HasColumnName("EVENTID_REVNO");
            });

            modelBuilder.Entity<WO>(entity =>
            {
                entity.HasNoKey();
            });
        }

        

        #endregion
    }
}
