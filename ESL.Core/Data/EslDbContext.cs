using ESL.Core.IConfiguration;
using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Data
{
    public class EslDbContext : DbContext, IEslDbContext
    {
        public EslDbContext(DbContextOptions<EslDbContext> options)
            : base(options)
        {

        }

        public DbSet<AllEvent> AllEvents { get; set; }

        public virtual DbSet<AllScadaUsersRole> Roles { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Constant> Constants { get; set; }

        public DbSet<Meter> Meters { get; set; }
    }
}
