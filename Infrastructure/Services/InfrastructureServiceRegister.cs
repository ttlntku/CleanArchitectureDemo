using Core.Repositories;
using Core.Repositories.Base;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class InfrastructureServiceRegister
    {
        public static void AddInfrastructureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DataContext>(m =>
                m.UseMySql(configuration.GetConnectionString("EmployeeDB"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("EmployeeDB")))
            );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}