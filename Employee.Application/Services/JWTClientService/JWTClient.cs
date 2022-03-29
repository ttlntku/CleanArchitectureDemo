using Employee.Application.Configs;
using Employee.Application.CQRS.Commands.LoginEmployee;
using Employee.Application.Persistence;
using Employee.Core.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Services.JWTClientService
{
    public class JWTClient : IJWTClient
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPersistenceFactory _persistenceFactory;
        public JWTClient(IEmployeeRepository employeeRepository, IPersistenceFactory persistenceFactory)
        {
            _employeeRepository = employeeRepository;
            _persistenceFactory = persistenceFactory;
        }
        public async Task<TokenDto> Authenticate(LoginEmployeeCommandDto employee)
        {
            var listEmployee = await _employeeRepository.GetAllAsync();

            if (!listEmployee.Any(
                x => x.Email.Equals(employee.Email) &&
                x.Password.Equals(employee.Password)))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_persistenceFactory.GetJWTConfig().GetJWTConfig().Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                       new Claim(ClaimTypes.Name, employee.Email)

                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDto { Token = tokenHandler.WriteToken(token)};
        }
    }
}
