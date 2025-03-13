using ESL.Api.Models.DAL;
using ESL.Api.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using Serilog.Context;
using System.Configuration;

namespace ESL.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // DbContextPool for Oracle
            builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
                        { options.UseOracle(builder.Configuration.GetConnectionString("ConnectionESL")); }, poolSize: 128);
                        //options.UseOracle(builder.Configuration.GetConnectionString("ConnectionESL")));

            // DbContext for Oracle
            //builder.Services.AddOracle<ApplicationDbContext>(builder.Configuration.GetConnectionString("ConnectionESL"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // DbContextPool for SQLServer
            //builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("SalesDB"));

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
            builder.Services.AddScoped<IMeterRepository, MeterRepository>();
            builder.Services.AddScoped<IAllEventRepository, AllEventRepository>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            // Forcing SwaggerUI on esl2-dev site only for testing

            //app.UseSwagger()
            //    .UseSwaggerUI(c =>
            //    {
            //        c.RoutePrefix = "";
            //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ESL API Swagger v1");
            //    });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
