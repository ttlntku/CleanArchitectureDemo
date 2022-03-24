using Employee.Core.Repositories;
using Employee.Core.Repositories.Base;
using Employee.Infrastructure.Data;
using Employee.Infrastructure.Repositories;
using Employee.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Services
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<MyDbContext>(m =>
                m.UseMySql(configuration.GetConnectionString("EmployeeDB"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("EmployeeDB")))
            );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
