using ESL.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.IConfiguration
{
    // GitHub.com/Kakoko/CleanArchitectureDI/CleanArchitecture.Infrastructure
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this
            IServiceCollection services)
        {
            services.AddDbContext<EslDbContext>(options => options.UseOracle(ApplicationDbContextHelpers.esl_connectionString,
                b => b.MigrationsAssembly(typeof(EslDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IEslDbContext>(provider => provider.GetService<EslDbContext>());

            return services;
        }
    }
}
