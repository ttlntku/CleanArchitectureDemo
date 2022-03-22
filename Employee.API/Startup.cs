using Employee.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Employee.Application.Handlers;
using System.Reflection;
using Employee.Core.Repositories;
using Employee.Infrastructure.Repositories;
using Employee.Core.Repositories.Base;
using Employee.Infrastructure.Repositories.Base;
using MediatR;
using AutoWrapper;
using Idoba.API.Helper.ApiResponse;

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
            services.AddDbContextPool<MyDbContext>(m => m.UseMySql(Configuration.GetConnectionString("EmployeeDB"), ServerVersion.AutoDetect(Configuration.GetConnectionString("EmployeeDB"))));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee.API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(GetAllEmployeeHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
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

            loggerFactory.AddLog4Net();

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
