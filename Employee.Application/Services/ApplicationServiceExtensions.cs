using Employee.Application.Validations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Employee.Application.Services
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationService(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}
