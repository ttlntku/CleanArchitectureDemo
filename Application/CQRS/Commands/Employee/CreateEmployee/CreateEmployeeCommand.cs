using Application.Constants;
using Application.CQRS.Responses;
using Core.Repositories;
using Application.Mappers;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.CQRS.Commands.Employee.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("First Name"))
                .MaximumLength(50).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_50("First Name"));

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Last Name"))
                .MaximumLength(50).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_50("Last Name"));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Email"))
                .MaximumLength(50).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_50("Email"));

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Date Of Birth"));

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(10).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_10("Phone Number"));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Password"))
                .MaximumLength(50).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_50("Password"));

        }
    }

    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeDto = MapperConfig.mapper.Map<CreateEmployeeCommandDto>(request);

            EmployeeEntity _employeeEntity = new EmployeeEntity()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                DateOfBirth = employeeDto.DateOfBirth,
                PhoneNumber = employeeDto.PhoneNumber,
                Email = employeeDto.Email,
                Password = employeeDto.Password
            };

            var newEmployee = await _employeeRepository.AddAsync(_employeeEntity);
            var employeeResponse = MapperConfig.mapper.Map<EmployeeResponse>(newEmployee);

            return employeeResponse;
        }
    }
}
