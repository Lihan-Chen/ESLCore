using ESL.Core.IConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Data
{
    public static class ServiceCollectionExtensions
    {

        //public static void RegisterYourLibrary(this IServiceCollection services, DbContext dbContext)
        //{
        //    if (dbContext == null)
        //    {
        //        throw new ArgumentNullException(nameof(dbContext));
        //    }

        //    services.AddScoped<IUnitOfWork, UnitOfWork>(uow => new UnitOfWork(dbContext));
        //}
    }
}
