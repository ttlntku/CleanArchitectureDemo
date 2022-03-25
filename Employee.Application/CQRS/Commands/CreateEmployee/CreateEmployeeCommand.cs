using Employee.Application.Constants;
using Employee.Application.CQRS.Responses;
using Employee.Application.Mappers;
using Employee.Core.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.CQRS.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
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
                .MaximumLength(10).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_10("Phone Number")); ;
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

            Employee.Core.Entities.Employee _employeeEntity = new Employee.Core.Entities.Employee()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                DateOfBirth = employeeDto.DateOfBirth,
                PhoneNumber = employeeDto.PhoneNumber,
                Email = employeeDto.Email
            };

            var newEmployee = await _employeeRepository.AddAsync(_employeeEntity);
            var employeeResponse = MapperConfig.mapper.Map<EmployeeResponse>(newEmployee);

            return employeeResponse;
        }
    }
}
