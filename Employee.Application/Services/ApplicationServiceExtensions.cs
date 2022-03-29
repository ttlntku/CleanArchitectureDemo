using Employee.Application.Configs;
using Employee.Application.Persistence;
using Employee.Application.Services.JWTClientService;
using Employee.Application.Validations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Employee.Application.Services
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationService(IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = new JWTConfig(configuration["SSO:Issuer"],
                configuration["SSO:Audience"],
                int.Parse(configuration["SSO:AccessTokenTimeLife"]),
                int.Parse(configuration["SSO:RefreshTokenTimeLife"]),
                int.Parse(configuration["SSO:KeepSessionTimeLife"]),
                configuration["SSO:SecreteKey"]);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient<IPersistenceFactory, PersistenceFactory>(b =>
            {
                return new PersistenceFactory(jwtConfig);
            });

            //Configure jwt authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var key = Encoding.UTF8.GetBytes(configuration["SSO:SecreteKey"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["SSO:Issuer"],
                    ValidAudience = configuration["SSO:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            services.AddTransient<IJWTClient, JWTClient>();
        }
    }
}
