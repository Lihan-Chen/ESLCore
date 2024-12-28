using ESL.Core.Data;
using ESL.Core.IRepositories;
using ESL.Core.Repositories;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace ESL.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Ref: https://github.com/MicrosoftDocs/mslearn-m365-microsoftgraph-dotnetcorerazor/blob/main/End/Startup.cs
            // Retrieve required permissions from appsettings
            var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

            // Add services to the container. per program.cs from testWebApi project
            // builder.Services.AddOracle<ApplicationDbContext>(new ApplicationDbContext(null,null, null));

            // Just point to the ApplicationDBContext in the ESL.Core and use the connection string defined there.  Otherwise, use the one defined below
            builder.Services.AddDbContext<ApplicationDbContext>();
            
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseOracle(ApplicationDbContextHelpers.esl_connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // string userID = builder.Configuration.GetSection(USERNAME);
            //var userID = GetValue<OptionsBuilderConfigurationExtensions>(USERNAME);

            //builder.Services.AddOracle<ApplicationDbContext>(builder.Configuration.GetConnectionString("ConnectionESL"));
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // 8/14
            // builder.Services.AddOracle<ApplicationDbContext>(builder.Configuration.GetConnectionString("ConnectionESL"));

            // For Database Verification, use SQLite

            // 8/14
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>   //(sp, options => 
            //options.UseOracle(builder.Configuration.GetConnectionString("ConnectionESL")));
            //.AddInterceptors(
            //.sp.GetRequiredService<UpdateAuditableInterceptor>())); //,
            // sp.GetRequiredService<InsertOutboxMessagesInterceptor>())
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IAllEventRepository, AllEventRepository>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //builder.Services.AddScoped<IConstantRepository, ConstantRepository>();

            //Unable to resolve service for type 'Microsoft.Extensions.Logging.ILogger' while attempting to activate 'ESL.Core.Repositories.AllEventRepository'

            // Add services to the container.
            // Add support for OpenId authentication
            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                // Microsoft identity platform web app that requires an auth code flow
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
                // Add ability to call Microsoft Graph APIs with specific permissions
                .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
                // Enable dependency injection for GraphServiceClient
                .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph")) //DownstreamApi
                // Add in-memory token cache
                .AddInMemoryTokenCaches();

            

            // For unit testing, use InMemoryDatabase
            // builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ESL"));
            // For real application use Oracle with ConnectionString of ESLConnection as defined in appsetting.json file
            // builder.Services.AddOracle<ApplicationDbContext>(builder.Configuration.GetConnectionString("ESLConnection")); // "name=ConnectionStrings:DefaultConnection"




            builder.Services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddRazorPages()
                .AddMicrosoftIdentityUI();

            //var logservice = GetLoggerFactory();

            //builder.Services.AddSingleton(logservice);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
