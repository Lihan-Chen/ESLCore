using ESL.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace ESL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<AllEvent> AllEvents { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
