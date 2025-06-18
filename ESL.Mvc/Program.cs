// <ms_docref_import_types>
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Constants = ESL.Mvc.Infrastructure.Graph.Constants;
using System.Net;
using ESL.Mvc.Services;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure;
using Microsoft.AspNetCore.Rewrite;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;
using ESL.Infrastructure.DataAccess.Repositories;
using ESL.Mvc.Infrastructure.Graph;
//using ESL.Mvc.DataAccess.Persistence;
using ESL.Application.Interfaces.IRepositories;
using ESL.Infrastructure.DataAccess;
using ESL.Application.Interfaces.IServices;
using ESL.Application.Services;
//using IEmployeeService = ESL.Application.Interfaces.IServices.IEmployeeService;
// </ms_docref_import_types>

namespace ESL.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConnectionESL = builder.Configuration.GetConnectionString("ConnectionESL");

            // <ms_docref_add_msal>
            // Ref: https://github.com/MicrosoftDocs/mslearn-m365-microsoftgraph-dotnetcorerazor/blob/main/End/Startup.cs
            // Retrieve required permissions from appsettings
            var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;  // MinimumSameSitePolicy = SameSiteMode.None for testing
                // Handling SameSite cookie according to https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1
                options.HandleSameSiteCookieCompatibility();
            });

            //builder.Services.AddOptions();

            //// This is required to be instantiated before the OpenIdConnectOptions starts getting configured.
            //// By default, the claims mapping will map claim names in the old format to accommodate older SAML applications.
            //// 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role' instead of 'roles'
            //// This flag ensures that the ClaimsIdentity claims collection will be built from the claims in the token
            //JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            //// Add Microsoft Graph support
            //builder.Services.AddSingleton<IMSGraphService, MSGraphService>();

            // Sign-in users with the Microsoft identity platform
            // builder.Services.AddAuthentication.AddJwtBearer();

            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                // Microsoft identity platform web app that requires an auth code flow
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))                
                // Add ability to call Microsoft Graph APIs with specific permissions
                .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
                // Enable dependency injection for GraphServiceClient
                .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph")) //DownstreamApi
                //.AddDownstreamApi("DownstreamApi", builder.Configuration.GetSection("DownstreamApi"))
                // Add in-memory token cache
                .AddInMemoryTokenCaches();
            // </ms_docref_add_msal>

            //// The following lines code instruct the asp.net core middleware to use the data in the "roles" claim in the Authorize attribute and User.IsInrole()
            //// See https://docs.microsoft.com/aspnet/core/security/authorization/roles?view=aspnetcore-2.2 for more info.
            //builder.Services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
            //{
            //    // The claim in the Jwt token where App roles are available.
            //    options.TokenValidationParameters.RoleClaimType = "roles";
            //});

            // Adding authorization policies that enforce authorization using ESL existing UserRoles Azure AD roles.
            // https://learn.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-9.0           
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Operator", policy => policy.RequireRole("Operator", "Administrator", "SuperAdmin"));
                options.AddPolicy("Admin", policy => policy.RequireRole("Administrator", "SuperAdmin"));
                options.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));

                // The following policies are used to enforce authorization using Azure AD roles.
                options.AddPolicy(AuthorizationPolicies.AssignmentToUserReaderRoleRequired, policy => policy.RequireClaim("roles", AppRole.UserReaders));
                options.AddPolicy(AuthorizationPolicies.AssignmentToUserReaderRoleRequired, policy => policy.RequireRole(AppRole.UserReaders));
                options.AddPolicy(AuthorizationPolicies.AssignmentToDirectoryViewerRoleRequired, policy => policy.RequireRole(AppRole.DirectoryViewers));
                options.AddPolicy("Admin", authBuilder =>
                {
                    authBuilder.RequireRole("Administrators");  // check if "Administrators" is the correct role name
                });
            });

            builder.Services.AddAuthorization(options =>
            {
                
            });

            #region ESLDbContext

            // <ms_docref_add_dbcontext>

            // Add the DbContextPool for Oracle to create a pool of Oracle connections to the container. This is recommended for high traffic applications.
            // https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-resilient-entity-framework-core-sql-connections
            //builder.Services.AddDbContextPool<EslDbContext>(options =>
            //                                                options.UseOracle(ConnectionESL, b =>
            //                                                                                 b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion23))
            //                                                       .LogTo(Console.WriteLine, LogLevel.Information)
            //                                                       .EnableSensitiveDataLogging(), poolSize: 128);
            
            builder.Services.AddDbContextPool<EslDbContext>((serviceProvider, options) =>
            {
                var logger = serviceProvider.GetRequiredService<ILogger<EslDbContext>>();

                options.UseOracle(ConnectionESL, b =>
                    b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion23))
                    .LogTo(message => logger.LogInformation(message), LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }, poolSize: 128);


            // AddDatabaseDeveloperPageExceptionFilter should only be used in the development environment
            // Need to Nuget Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Add health checks CD1061 error
            //builder.Services.AddHealthChecks()
            //                .AddDbContextCheck<EslDbContext>();

            // The following maybe used in future releases:

            // 1 -
            // Just point to the EslDBContext in the ESL.Core and use the connection string defined in EslDbContextHelpers.
            // https://stackoverflow.com/questions/73193652/net-6-ef-core-dbcontext-and-models-in-separate-class-libary
            // builder.Services.AddDbContext<EslDbContext>();

            // 2 -
            // AddDbContextPool is used to create a pool of connections to the database. This is recommended for high traffic applications.
            // builder.Services.AddDbContextPool<EslDbContext>(options =>
            //              { options.UseOracle(EslDbContextHelpers.esl_connectionString); }, poolSize: 128); //EslDbContextHelpers.esl_connectionString

            // builder.Services.AddScoped(provider => provider.GetRequiredService<EslDbContext>());

            // 3 -
            // use helper for ConnectionString
            // builder.Services.AddDbContextPool<EslDbContext>(options =>
            //              options.UseOracle(ApplicationDbContextHelpers.esl_connectionString));

            // 4 -
            // builder.Services.AddOracle<ApplicationDbContext>(builder.Configuration.GetConnectionString("ConnectionESL"));
            // builder.Services.ImplementPersistence(); // (builder.Configuration);

            //var serviceProvider = builder.Services.BuildServiceProvider();
            //using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            //{
            //}

            // </ms_docref_add_dbcontext>

            //// <ms_docref_add_ESL.Core_dbcontext>
            /// https://stackoverflow.com/questions/59753218/how-to-use-dbcontext-in-separate-class-library-net-core
            //builder.Services.AddOracle<EslDbContext>(builder.Configuration.GetConnectionString("ConnectionESL"));

            // Remove the following line to avoid ASP0000 warning
            //ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
            //EslDbContext applicationDbContext = serviceProvider.GetService<EslDbContext>();
            //builder.Services.RegisterYourLibrary(EslDbContext); // <-- Here passing the DbConext instance to the class library

            // Instead, use dependency injection to get the EslDbContext
            //builder.Services.AddScoped(provider =>
            //{
            //    var optionsBuilder = new DbContextOptionsBuilder<EslDbContext>();
            //    optionsBuilder.UseOracle(EslDbContextHelpers.esl_connectionString);
            //    //var context = provider.GetRequiredService<EslDbContext>();
            //    return new EslDbContext(optionsBuilder.Options);
            //    // Register your library with the context
            //    // provider.RegisterYourLibrary(context);
            //    //return context;
            //});
            // </ms_docref_add_ESL.Core_dbcontext>

            // ToDo for version 2
            // For things like soft delete with update approach
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>   //(sp, options => 
            //options.UseOracle(builder.Configuration.GetConnectionString("ConnectionESL")));
            //.AddInterceptors(
            //.sp.GetRequiredService<UpdateAuditableInterceptor>())); //,
            // sp.GetRequiredService<InsertOutboxMessagesInterceptor>())

            #endregion ESLDbContext

            // string userID = builder.Configuration.GetSection(USERNAME);
            //var userID = GetValue<OptionsBuilderConfigurationExtensions>(USERNAME);

            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(uow => new UnitOfWork(EslDbContext));

            // configure repositories
            //builder.Services.AddScoped<FacilityRepository>();

            builder.Services.AddScoped<IAllEventRepository, AllEventRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
            builder.Services.AddScoped<IEmpRoleRepository, EmpRoleRepository>();
            builder.Services.AddScoped<IConstantRepository, ConstantRepository>();
            builder.Services.AddScoped<ILogTypeRepository, LogTypeRepository>();
            builder.Services.AddScoped<IConstantRepository, ConstantRepository>();
            builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
            builder.Services.AddScoped<IMeterRepository, MeterRepository>();
            builder.Services.AddScoped<ISearchDTORepository, SearchDTORepository>();


            // configure services https://github.com/sanckh/YourLibraryApp/blob/main/YourLibrary/Startup.cs
            builder.Services.AddScoped<ESL.Application.Interfaces.IServices.ICoreService, ESL.Application.Services.CoreService>();
            //builder.Service.AddScoped<IConstantService, ConstantService>();
            //builder.Service.AddScoped<IAuthorService, AuthorService>();
            //builder.Service.AddScoped<IPublisherService, PublisherService>();
            //builder.Service.AddScoped<IAccountService, AccountService>();
            //builder.Service.AddScoped<IUserService, UserService>();

            //API Service(s)
            //service.AddHttpClient<GoogleBooksService>();

            // <ms_docref_add_default_controller_for_sign-in-out>
            // builder.Services.AddRazorPages().AddMvcOptions(options =>
            builder.Services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));    
            })
            // View Component support, the placeholder {0} represents the path Components/{View Component Name}/{View Name}.
            // https://learn.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-9.0
            .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/{0}.cshtml");
                })
            // Add the Microsoft Identity UI pages for signin/out
            .AddMicrosoftIdentityUI();


            // </ms_docref_add_default_controller_for_sign-in-out>
            builder.Services.AddHttpContextAccessor();
            
            builder.Services.AddRazorPages().AddMvcOptions(options => options.EnableEndpointRouting = false)
                .AddMicrosoftIdentityUI();

            ////
            builder.Services.AddServerSideBlazor()
               .AddMicrosoftIdentityConsentHandler();

            //var logservice = GetLoggerFactory();

            //builder.Services.AddSingleton(logservice);

            // Adding the IHttpContextAccessor servive to the Dependency Injection IOC Container
            // ref: https://dotnettutorials.net/lesson/cookies-in-asp-net-core-mvc/
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // <ms_docref_add_session>
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".ESL.Session";
                options.IdleTimeout = TimeSpan.FromHours(12);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Path = "/";
                options.Cookie.Expiration = TimeSpan.FromDays(30);
            });
            // </ms_docref_add_session>


            // Add OutputCache Service
            builder.Services.AddOutputCache(options =>
            {
                options.AddPolicy("Cache12Hours", builder => builder.Expire(TimeSpan.FromHours(12)).Tag("Cache12Hours"));  //people https://www.youtube.com/watch?v=DN2g-T48VjM
                // need to follow through in controller dependency injection of IOutputCache, and in the controller method evicting the cache as needed (shown in the reference video)
            }
                );

            var app = builder.Build();

            // Add after other middleware configurations
            app.Use(async (context, next) =>
            {
                using var scope = app.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<EslDbContext>();

                if (!dbContext.Database.CanConnect())
                {
                    throw new InvalidOperationException("Database connection not available");
                }

                await next();
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else // Development Environment https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/blob/master/5-WebApp-AuthZ/5-1-Roles/Startup.cs
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        // Per suggestion by Copilot for DbContext error handling
                        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                        var exception = exceptionHandlerPathFeature?.Error;

                        if (exception is InvalidOperationException &&
                            exception.Message.Contains("Database"))
                        {
                            context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                error = "Database service unavailable",
                                details = exception.Message
                            });
                        }

                        // Handle other regular exceptions
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; ;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><head>\r\n");

                        await context.Response.WriteAsync("</head>\r\n");
                        await context.Response.WriteAsync("<meta name=\"viewport\" content=\"width = device - width, initial - scale = 1\"><style>.collapsible{color: #777;cursor: pointer;padding: 18px;width: 100%;border: none;text-align: left;outline: none;font-size: 15px;}.active, .collapsible:hover {background-color: #555;}.collapsible:after {content: '\\002B';color: #777;font-weight: bold;float: right;margin-left: 5px;}.active:after {content: \"\\2212\";}.content {padding: 0 18px;max-height: 0;overflow: hidden;transition: max-height 0.2s ease-out;background-color: #f1f1f1;}</style>");
                        await context.Response.WriteAsync("<body>\r\n");
                        await context.Response.WriteAsync("<a href=\"/\">Back to Home</a><br>\r\n");
                        await context.Response.WriteAsync("<h2>Exception Overview</h2><br>\r\n");

                        //var exceptionHandlerPathFeature =
                        //    context.Features.Get<IExceptionHandlerPathFeature>();
                        if (exceptionHandlerPathFeature?.Error is Exception)
                        {
                            if (exceptionHandlerPathFeature.Error.InnerException != null)
                            {
                                if (exceptionHandlerPathFeature.Error.InnerException.Message.Contains(Constants.UserConsentDeclinedError))
                                {
                                    await context.Response.WriteAsync($"<h3>{Constants.UserConsentDeclinedErrorMessage}</h3><br>\r\n");
                                }
                                else
                                {
                                    await context.Response.WriteAsync($"<h3>{exceptionHandlerPathFeature?.Error.InnerException?.Message}</h3><br>\r\n");

                                }
                            }
                            else
                            {
                                await context.Response.WriteAsync($"<h3>{exceptionHandlerPathFeature?.Error.Message}</h3><br>\r\n");
                            }

                            await context.Response.WriteAsync("<button class=\"collapsible\">Click for Exception Full Stack</button>\r\n");
                            await context.Response.WriteAsync("<div class=\"content\"><p>");
                            await context.Response.WriteAsync(exceptionHandlerPathFeature?.Error.StackTrace);
                            await context.Response.WriteAsync("</p></div>");
                        }

                        await context.Response.WriteAsync("<script>var coll = document.getElementsByClassName(\"collapsible\");var i;for (i = 0; i < coll.length; i++) {coll[i].addEventListener(\"click\", function() {this.classList.toggle(\"active\");var content = this.nextElementSibling;if (content.style.maxHeight){content.style.maxHeight = null;} else {content.style.maxHeight = content.scrollHeight + \"px\";}});}</script>");
                        await context.Response.WriteAsync("</body></html>\r\n");
                    });
                });
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // For using directory StaticFiles (to be changed on server?)
            //app.UseStaticFiles(new StaticFileOptions
            //    {
            //        FileProvider = new PhysicalFileProvider(
            //            Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
            //            RequestPath = "StaticFiles"
            //    }
            //);

            app.UseRouting();
            app.UseCors();

            // <ms_docref_enable_authz_capabilities>           
            app.UseAuthentication();
            app.UseAuthorization();
            // </ms_docref_enable_authz_capabilities>

            // </ms_docref_enable_session>
            // Must be called after UseRouting, and before MapDefaultControllerRoute
            app.UseSession();
            // </ms_docref_enable_session>

            app.UseOutputCache();

            //app.UseEndpoints(endpoints => {
            //    endpoints.MapControllers();
            //});

            // Configure endpoints
            app.MapHealthChecks("/health");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseMvc().UseMvcWithDefaultRoute();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // The following comes from ESL.MVC4 route.config
            //app.MapControllerRoute(
            //    "Del", // Route name
            //    "{controller}/Del/", // URL with parameters: int facilNo, int logTypeNo, string startDate, string endDate, string keyWords, string andOr
            //    new
            //    {
            //        controller = "AllEvents",
            //        action = "Del",
            //        //{facilNo, logTypeNo, startDate, endDate, keyWords, andOr}
            //        //facilNo = UrlParameter.Optional,
            //        //logTypeNo = UrlParameter.Optional,
            //        //startDate = UrlParameter.Optional,
            //        //endDate = UrlParameter.Optional,
            //        //keyWords = UrlParameter.Optional,
            //        //andOr = UrlParameter.Optional,
            //        Area = ""
            //    },
            //     new[] { "ESL.Mvc.Controllers" }
            //);

            //app.MapControllerRoute(
            //    "RelatedTo", // Route name
            //    "AllEvents/SearchRelatedToList/", // URL with parameters: int facilNo, int logTypeNo, string startDate, string endDate, string keyWords, string andOr
            //    new
            //    {
            //        controller = "AllEvents",
            //        action = "SearchRelatedToList",
            //        //{facilNo, logTypeNo, startDate, endDate, keyWords, andOr}
            //        //facilNo = UrlParameter.Optional,
            //        //logTypeNo = UrlParameter.Optional,
            //        //startDate = UrlParameter.Optional,
            //        //endDate = UrlParameter.Optional,
            //        //keyWords = UrlParameter.Optional,
            //        //andOr = UrlParameter.Optional,
            //        Area = ""
            //    },
            //    new[] { "ESL.Mvc.Controllers" }

            //    );
            //app.MapControllerRoute(
            //    "AddName", // Route name
            //    "AllEvents/AddName/", // URL with parameters: int facilNo, int logTypeNo, string startDate, string endDate, string keyWords, string andOr
            //    new
            //    {
            //        controller = "AllEvents",
            //        action = "AddName",
            //        Area = ""
            //    },
            //    new[] { "ESL.Mvc.Controllers" }
            //);

            //app.MapControllerRoute(
            //"Default" // Route name
            //, "{controller}/{action}/{[id?]}" // URL with parameters
            //, new { area = "Admin", controller = "Home", action = "Index"} // , id = UrlParameter.Optional defaults
            //, new[] { "ESL.Mvc.Areas.Admin.Controllers" } // Namespace of controllers in root area
            //);

            app.UseRewriter(
                new RewriteOptions().Add(
                    context =>
                    {
                        if (context.HttpContext.Request.Path == "/MicrosoftIdentity/Account/SignedOut")
                        {
                            context.HttpContext.Response.Redirect("/");
                        }
                    }));

            app.MapRazorPages();

            app.Run();
        }

        /// <summary>
        /// Gets the secret from key vault via an enabled Managed Identity.
        /// https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/blob/master/2-WebApp-graph-user/2-1-Call-MSGraph/Startup.cs
        /// </summary>
        /// <remarks>https://github.com/Azure-Samples/app-service-msi-keyvault-dotnet/blob/master/README.md</remarks>
        /// <returns></returns>
        private string GetSecretFromKeyVault(string tenantId, string secretName)
        {
            // this should point to your vault's URI, like https://<yourkeyvault>.vault.azure.net/
            string uri = Environment.GetEnvironmentVariable("KEY_VAULT_URI");
            DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions();

            // Specify the tenant ID to use the dev credentials when running the app locally
            options.VisualStudioTenantId = tenantId;
            options.SharedTokenCacheTenantId = tenantId;
            SecretClient client = new SecretClient(new Uri(uri), new DefaultAzureCredential(options));

            // The secret name, for example if the full url to the secret is https://<yourkeyvault>.vault.azure.net/secrets/ENTER_YOUR_SECRET_NAME_HERE
            Response<KeyVaultSecret> secret = client.GetSecretAsync(secretName).Result;

            return secret.Value.Value;
        }
    }
}
