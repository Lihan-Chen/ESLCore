using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using ESL.Api.Models.BusinessEntities;
using Microsoft.Extensions.Logging.Console;

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

        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseOracle("Data Source=ODev41.world;Persist Security Info=false;User ID=ESL;Password=MWDesl01_#;"); //?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.");
        {
            //    //use this to configure the contex's Connection String
            //    optionsBuilder.UseOracle(@"user id=esl;password=MWDesl01_#;data source=dev7.world;Persist Security Info=false;Min Pool Size=10;Connection Lifetime=120;");

        }

        //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use this to configure the model
        }

        public DbSet<ViewAlleventsCurrent> ViewAlleventsCurrents { get; set; }

        public DbSet<AllEvent> AllEvents {  get; set; }  

        public DbSet<AllScadaUsersRole> AllScadaUsersRoles { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Facility> Facilities { get; set; }

        public virtual DbSet<FlowChange> FlowChanges { get; set; }

        public virtual DbSet<LogType> LogTypes { get; set; }

        public virtual DbSet<BusinessEntities.Meter> Meters { get; set; }

        public virtual DbSet<UserSession> UsersSessions { get; set; }


    }
}
