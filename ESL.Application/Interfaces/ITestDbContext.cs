using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Application.Interfaces
{
    // https://stackoverflow.com/questions/12263514/why-dbcontext-doesnt-implement-idbcontext-interface
    public interface ITestDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //DbSet Set(Type entityType);
        //int SaveChanges();
        //IEnumerable<DbEntityValidationResult> GetValidationErrors();
        ////DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        ////DbEntityEntry Entry(object entity);
        string ConnectionString { get; set; }
        public bool AutoDetectChangedEnabled { get; set; }
        public void ExecuteSqlCommand(string p, params object[] o);
        public void ExecuteSqlCommand(string p);
    }
}
