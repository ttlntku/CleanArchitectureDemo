using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Services.JWTClientService
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
