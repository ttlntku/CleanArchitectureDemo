using Employee.Application.Configs;
using Employee.Application.CQRS.Commands.LoginEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Services.JWTClientService
{
    public interface IJWTClient
    {
        Task<TokenDto> Authenticate(LoginEmployeeCommandDto employee);
    }
}
