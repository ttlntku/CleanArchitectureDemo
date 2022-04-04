using Application.Constants;
using Application.Services.JWTClientService;
using Application.Mappers;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Login
{
    public class LoginCommand : IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public class LoginEmployeeCommandValidator : AbstractValidator<LoginCommand>
        {
            public LoginEmployeeCommandValidator()
            {
                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Email"));

                RuleFor(x => x.Password)
                    .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Password"));
            }
        }

        public class LoginEmployeeHandler : IRequestHandler<LoginCommand, TokenDto>
        {
            private readonly IJWTClient _jwtClient;

            public LoginEmployeeHandler(IJWTClient jwtClient)
            {
                _jwtClient = jwtClient;
            }

            public async Task<TokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var loginDto = MapperConfig.mapper.Map<LoginCommandDto>(request);
                    var tokenDto = await _jwtClient.Authenticate(loginDto);

                    return tokenDto;
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }
    }
}
