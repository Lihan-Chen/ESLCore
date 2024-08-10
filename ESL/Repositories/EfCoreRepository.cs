using ESL.API.Repositories;
using ESL.API.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Identity.Web.UI.Areas.MicrosoftIdentity.Pages.Account;
using Microsoft.Graph.TermStore;

namespace ESL.API.Repositories
{
    public abstract class EfCoreRepository<TEntity, TContext> : IEfCoreRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext context;
        public EfCoreRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                return await context.SaveChangesAsync();
            }

            return 0;

            // if Task<TEntity>
            // return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            //return await context.Set<TEntity>().FindAsync(id);
            var result = await context.Set<TEntity>().FindAsync(id);
            if (result == null)
            {
                throw new Exception("Unable to find the {typeof(TEntity)}"); // marcinstelmach/Ecommerce.Api/Repository.cs // StreetwoodExceptionErrorCode.GenericNotExist(typeof(TEntity))
            }

            return result;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

    }
}
