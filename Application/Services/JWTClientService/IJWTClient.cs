using Application.CQRS.Commands.Login;
using System.Threading.Tasks;

namespace Application.Services.JWTClientService
{
    public interface IJWTClient
    {
        Task<TokenDto> Authenticate(LoginCommandDto employee);
    }
}
