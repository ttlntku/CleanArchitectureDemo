using Application.CQRS.Commands.Login;
using Application.Services.PersistenceFactoryService;
using Core.Helpers;
using Core.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.JWTClientService
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
        public async Task<TokenDto> Authenticate(LoginCommandDto employee)
        {
            var employeeEntity = await _employeeRepository.GetEmployeeByEmailAndPassword(employee.Email, employee.Password);

            if (employeeEntity is null)
            {
                return null;
            }

            var scope = EmployeeRole.RoleMapper.Where(s => s.Key.Equals(employeeEntity.Role)).Select(s => s.Value).FirstOrDefault();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_persistenceFactory.GetJWTConfig().GetJWTConfig().Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                       new Claim(ClaimTypes.Name, employeeEntity.FirstName),
                       new Claim(ClaimTypes.Email, employeeEntity.Email),
                       new Claim(ClaimTypes.Role, scope),
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDto { Token = tokenHandler.WriteToken(token) };
        }
    }
}
