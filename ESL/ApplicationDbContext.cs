using ESL.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ESL.Web.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Facility> facilities { get; set; }
        public DbSet<AllEvent> AllEvents { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, Configuration configuration)
        //{
        //        //optionsBuilder.UseOracle(Configuration.GetSection("ESLConnection");
        //}

    }
}
