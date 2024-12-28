// <ms_docref_import_types>
using ESL.Core.Data;
using ESL.Core.IRepositories;
using ESL.Core.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Constants = ESL.Mvc.Infrastructure.Constants;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using ESL.Mvc.Infrastructure;
using ESL.Mvc.Services;
// </ms_docref_import_types>



namespace ESL.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // <ms_docref_add_msal>
            // Ref: https://github.com/MicrosoftDocs/mslearn-m365-microsoftgraph-dotnetcorerazor/blob/main/End/Startup.cs
            // Retrieve required permissions from appsettings
            var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

            //builder.Services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
            //    // Handling SameSite cookie according to https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1
            //    options.HandleSameSiteCookieCompatibility();
            //});

            //builder.Services.AddOptions();

            //// This is required to be instantiated before the OpenIdConnectOptions starts getting configured.
            //// By default, the claims mapping will map claim names in the old format to accommodate older SAML applications.
            //// 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role' instead of 'roles'
            //// This flag ensures that the ClaimsIdentity claims collection will be built from the claims in the token
            //JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            //// Add Microsoft Graph support
            //builder.Services.AddSingleton<IMSGraphService, MSGraphService>();

            // Sign-in users with the Microsoft identity platform
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

            //// Adding authorization policies that enforce authorization using Azure AD roles.
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationPolicies.AssignmentToUserReaderRoleRequired, policy => policy.RequireRole(AppRole.UserReaders));
                options.AddPolicy(AuthorizationPolicies.AssignmentToDirectoryViewerRoleRequired, policy => policy.RequireRole(AppRole.DirectoryViewers));
            });

            // <ms_docref_add_dbcontext>
            // Just point to the ApplicationDBContext in the ESL.Core and use the connection string defined there.  Otherwise, use the one defined below
            builder.Services.AddDbContext<ApplicationDbContext>();

            // use helper
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseOracle(ApplicationDbContextHelpers.esl_connectionString));

            // AddDatabaseDeveloperPageExceptionFilter should only be used in the development environment
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // </ms_docref_add_dbcontext>

            // string userID = builder.Configuration.GetSection(USERNAME);
            //var userID = GetValue<OptionsBuilderConfigurationExtensions>(USERNAME);

            // For Database Verification, use SQLite

            // For things like soft delete with update approach
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

            // For unit testing, use InMemoryDatabase
            // builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ESL"));
            // For real application use Oracle with ConnectionString of ESLConnection as defined in appsetting.json file
            // builder.Services.AddOracle<ApplicationDbContext>(builder.Configuration.GetConnectionString("ESLConnection")); // "name=ConnectionStrings:DefaultConnection"



            // <ms_docref_add_default_controller_for_sign-in-out>
            // builder.Services.AddRazorPages().AddMvcOptions(options =>
            builder.Services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddMicrosoftIdentityUI();


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
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            // </ms_docref_add_session>

            var app = builder.Build();

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
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; ;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><head>\r\n");

                        await context.Response.WriteAsync("</head>\r\n");
                        await context.Response.WriteAsync("<meta name=\"viewport\" content=\"width = device - width, initial - scale = 1\"><style>.collapsible{color: #777;cursor: pointer;padding: 18px;width: 100%;border: none;text-align: left;outline: none;font-size: 15px;}.active, .collapsible:hover {background-color: #555;}.collapsible:after {content: '\\002B';color: #777;font-weight: bold;float: right;margin-left: 5px;}.active:after {content: \"\\2212\";}.content {padding: 0 18px;max-height: 0;overflow: hidden;transition: max-height 0.2s ease-out;background-color: #f1f1f1;}</style>");
                        await context.Response.WriteAsync("<body>\r\n");
                        await context.Response.WriteAsync("<a href=\"/\">Back to Home</a><br>\r\n");
                        await context.Response.WriteAsync("<h2>Exception Overview</h2><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();
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

            app.UseRouting();
            app.UseCors();

            // <ms_docref_enable_authz_capabilities>           
            app.UseAuthentication();
            app.UseAuthorization();
            // </ms_docref_enable_authz_capabilities>

            // </ms_docref_enable_session>
            app.UseSession();
            // </ms_docref_enable_session>

            //app.UseEndpoints(endpoints => {
            //    endpoints.MapControllers();
            //});

            app.UseMvc().UseMvcWithDefaultRoute();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
