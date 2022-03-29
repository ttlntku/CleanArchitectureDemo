using Employee.Application.Constants;
using Employee.Application.Mappers;
using Employee.Application.Services.JWTClientService;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.CQRS.Commands.LoginEmployee
{
    public class LoginEmployeeCommand : IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginEmployeeCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public class LoginEmployeeCommandValidator : AbstractValidator<LoginEmployeeCommand>
        {
            public LoginEmployeeCommandValidator()
            {
                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Email"));

                RuleFor(x => x.Password)
                    .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Password"));
            }
        }

        public class LoginEmployeeHandler : IRequestHandler<LoginEmployeeCommand, TokenDto>
        {
            private readonly IJWTClient _jwtClient;

            public LoginEmployeeHandler(IJWTClient jwtClient)
            {
                _jwtClient = jwtClient;
            }

            public async Task<TokenDto> Handle(LoginEmployeeCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var loginDto = MapperConfig.mapper.Map<LoginEmployeeCommandDto>(request);

                    var tokenDto =  await _jwtClient.Authenticate(loginDto);

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
