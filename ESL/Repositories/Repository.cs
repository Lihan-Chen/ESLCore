using ESL.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESL.Web.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;
        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }
         public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();

        }
        
        public async Task UpdateAsync (TEntity entity)
        {
            Context.ChangeTracker.
            
            Task<TEntity> UpdateAsync(TEntity entity); await Context.Set<TEntity>().AddAsync(entity);
        }


        public async Task DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

       
    }
}
