
namespace testCoreWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

                //app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
                //{
                //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                //    options.RoutePrefix = string.Empty;

                //    // https://github.dev/blazorhero/CleanArchitecture/blob/11f810d97cb66a251dfbee335b581fa9f1d1beab/src/Server/Extensions/ApplicationBuilderExtensions.cs#L45#L54
                //    //options.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(Program).Assembly.GetName().Name);
                //    //options.RoutePrefix = "swagger";
                //    //options.DisplayRequestDuration();

                //    // useful info: https://stackoverflow.com/questions/63058563/publishing-web-api-with-swagger-on-iis
                //});
            }
            

            //app.UseSwagger();

            //// Forcing SwaggerUI on esl2-dev site only for testing
            //app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //    options.RoutePrefix = string.Empty;
            //});

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
