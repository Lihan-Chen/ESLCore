using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.EntityFrameworkCore;
using ESL.Repositories;

namespace ESL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Ref: https://github.com/MicrosoftDocs/mslearn-m365-microsoftgraph-dotnetcorerazor/blob/main/End/Startup.cs
            // Retrieve required permissions from appsettings
            var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

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

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //builder.Services.AddDbContext<ApplicationDbContext>




            builder.Services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.AddRazorPages()
                .AddMicrosoftIdentityUI();

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
