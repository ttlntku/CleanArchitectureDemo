using Application.Configs;
using Application.Mappers;
using Application.Services.JWTClientService;
using Application.Services.PersistenceFactoryService;
using Application.Validations;
using AutoMapper;
using Core.Helpers;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Services
{
    public static class ApplicationServiceRegister
    {
        public static void AddApplicationService(IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = new JWTConfig(configuration["SSO:Issuer"],
                configuration["SSO:Audience"],
                int.Parse(configuration["SSO:AccessTokenTimeLife"]),
                int.Parse(configuration["SSO:RefreshTokenTimeLife"]),
                int.Parse(configuration["SSO:KeepSessionTimeLife"]),
                configuration["SSO:SecretKey"]);

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
                var key = Encoding.UTF8.GetBytes(configuration["SSO:SecretKey"]);
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

            //Add authorization
            services.AddAuthorization(o =>
            {
                o.AddPolicy(EmployeeRole.ROLE_USER_NAME, p => p.RequireClaim("scope", $"[{EmployeeRole.ROLE_USER_NAME}]"));
                o.AddPolicy(EmployeeRole.ROLE_ADMIN_NAME, p => p.RequireClaim("scope", $"[{EmployeeRole.ROLE_ADMIN_NAME}]"));
            });

            services.AddTransient<IJWTClient, JWTClient>();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            //services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
        }
    }
}
