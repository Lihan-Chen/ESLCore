using ESL.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Infrastructure.DataAccess.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly EslDbContext _context;

        protected BaseRepository(EslDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected void ValidateContext()
        {
            if (_context == null || !_context.Database.CanConnect())
            {
                throw new InvalidOperationException("Database context is not available");
            }
        }
    }
}


