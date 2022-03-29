using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.CQRS.Commands.LoginEmployee
{
    public class LoginEmployeeCommandDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
