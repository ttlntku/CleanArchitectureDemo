using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoWrapper;
using Idoba.API.Helper.ApiResponse;
using Employee.Application.Services;
using Employee.Infrastructure.Services;

namespace Employee.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Configure validators
                //.AddFluentValidation(fv => {
                //    //fv.RegisterValidatorsFromAssemblyContaining<CreateEmployeeHandler>();
                //    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                //});

            //Configure swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee.API", Version = "v1" });
            });

            //Configure application service
            ApplicationServiceExtensions.AddApplicationService(services);

            //Configure repository dependency injections
            InfrastructureServiceExtensions.AddInfrastructureService(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee.API v1"));
            }

            //app.UseHttpsRedirection(); //rediction to ssl . no apply it for development
            app.UseApiResponseAndExceptionWrapper<MapResponseObject>(
                new AutoWrapperOptions
                {
                    UseApiProblemDetailsException = true,
                    ApiVersion = "1.0.0",
                    UseCustomSchema = true,
                    IgnoreNullValue = false
                }
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
