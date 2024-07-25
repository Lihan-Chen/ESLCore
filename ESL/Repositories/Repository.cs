using ESL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ESL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;
        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<T>> GetAllAync()
        {
            return await Context.Set<T>().toListAsync();
        }
        public Async Task<T> Get(int? id)
        {
            return Context.Set<T>().FindAsync(id);
        }
        public async task Add(T entity)
        {
            await Context.Set<T>().Add(entity);
        }
        public async task Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
    }
}
