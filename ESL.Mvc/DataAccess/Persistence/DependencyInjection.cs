using ESL.Core.IConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ESL.Mvc.DataAccess.Persistence
{
    // GitHub.com/Kakoko/CleanArchitectureDI/CleanArchitecture.Infrastructure
    // This serves as an example for Dependency Injection in the Infrastructure layer
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this
            IServiceCollection services)
        {
            services.AddDbContext<EslDbContext>(options => options.UseOracle(EslDbContextHelpers.esl_connectionString,
                b => b.MigrationsAssembly(typeof(EslDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IEslDbContext>(provider => provider.GetService<EslDbContext>());

            return services;
        }
    }
}
