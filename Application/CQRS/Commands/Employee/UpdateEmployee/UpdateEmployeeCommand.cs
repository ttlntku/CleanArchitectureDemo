using Application.Constants;
using Application.CQRS.Responses;
using Core.Helpers;
using Core.Repositories;
using Application.Mappers;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Commands.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Int16 Role { get; set; }

    }

    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Id"));
        }
    }

    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _employeeRepository = employeeRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeDto = MapperConfig.mapper.Map<UpdateEmployeeCommandDto>(request);
            var loginName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var toUpdateEmployee = await _employeeRepository.GetByIdAsync(employeeDto.Id);

            if (toUpdateEmployee is null)
            {
                return null;
            }

            toUpdateEmployee.FirstName ??= employeeDto.FirstName;
            toUpdateEmployee.LastName ??= employeeDto.LastName;
            toUpdateEmployee.DateOfBirth = CustomUtilities.IsNullDatetime(employeeDto.DateOfBirth) ? toUpdateEmployee.DateOfBirth : employeeDto.DateOfBirth;
            toUpdateEmployee.PhoneNumber ??= employeeDto.PhoneNumber;
            toUpdateEmployee.Email ??= employeeDto.Email;
            toUpdateEmployee.Password ??= employeeDto.Password;
            //toUpdateEmployee.Role ??= employeeDto.Role;
            toUpdateEmployee.UpdatedBy = "KIEU";
            toUpdateEmployee.UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);

            var updatedEmployee = await _employeeRepository.UpdateAsync(toUpdateEmployee, loginName);
            var employeeResponse = MapperConfig.mapper.Map<EmployeeResponse>(updatedEmployee);

            return employeeResponse;
        }
    }
}
