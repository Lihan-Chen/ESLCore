using ESL.Core.Data;
using ESL.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace ESL.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //DbContext

        protected ApplicationDbContext _context;

        internal DbSet<T> dbSet;

        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            this._context = context;
            this.dbSet = context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }


        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            var result = await dbSet.Where(predicate).AsNoTracking().ToListAsync();

            if (result != null) return result;

            return null;
        }

        public virtual async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        // SoftDelete

        public virtual async Task Delete(T entity)
        {

        }

        //public virtual Task Delete(int id)
        //{
        //    //var entity = GetById(id);

        //    //if (entity != null) dbSet.Remove(entity);
        //    //return true;

        //    try
        //    {
        //        var exist = dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

        //        if (exist == null) return null;

        //            //return exist;

        //            dbSet.Remove(exist);

        //        //ToDo                
        //        return exist;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(GenericRepository<T>));
        //    }
        //}

        public virtual Task Upsert(T entity)
        {
            throw new NotImplementedException();

            //try
            //{
            //    var existing = dbSet.Where(x => x == entity).FirstOrDefaultAsync();

            //    if (existing == null)
            //        dbSet.Add(entity);

            //    //existing.FirstName = entity.FirstName;
            //    //existing.LastName = entity.LastName;
            //    //existing.FacilNo = entity.FacilNo;
            //    _context.Entry<T>(entity).CurrentValues.SetValues(entity);
            //    //return entity;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(T));
            //}            
        }

        //ToDo
        // virtual and to override in downstream repositories with Soft Delete
        public virtual Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        // marcinstelmach/Ecommerce.Api/Repository.cs
        //public async Task<T> GetAndEnsureExistAsync(Guid id)
        //{
        //    var result = await dbSet.FindAsync(id);
        //    if (result == null)
        //    {
        //        throw new StreetwoodException(ErrorCode.GenericNotExist(typeof(T)));
        //    }

        //    return result;
        //}

        //public async Task Delete(string key)
        //{
        //    using var context = new SidekickContext(options);
        //    var cache = await context.Caches.FindAsync(key);
        //    if (cache != null)
        //    {
        //        context.Caches.Remove(cache);
        //        await context.SaveChangesAsync();
        //    }
        //}
    }
}
