using ESL.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace ESL.Models
{
    public class ESLDbContext: DbContext
    { 
        public ESLDbContext(DbContextOptions<ESLDbContext> options)
            : base(options) { }

        public DbSet<Facility> facilities { get; set; }
        public DbSet<AllEvent> AllEvents { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, Configuration configuration)
        //{
        //        //optionsBuilder.UseOracle(Configuration.GetSection("ESLConnection");
        //}

    }
}
