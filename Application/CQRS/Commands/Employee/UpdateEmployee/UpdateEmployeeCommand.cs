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
using AutoMapper;

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
        private IMapper _mapper;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeDto = _mapper.Map<UpdateEmployeeCommandDto>(request);
            var loginName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var toUpdateEmployee = await _employeeRepository.GetByIdAsync(employeeDto.Id);

            if (toUpdateEmployee is null)
            {
                return null;
            }

            toUpdateEmployee.FirstName = CustomUtilities.IsNullOrSecondValue<string>(employeeDto.FirstName, toUpdateEmployee.FirstName);
            toUpdateEmployee.LastName = CustomUtilities.IsNullOrSecondValue<string>(employeeDto.LastName, toUpdateEmployee.LastName);
            toUpdateEmployee.DateOfBirth = CustomUtilities.IsNullOrSecondValue<DateTime>(employeeDto.DateOfBirth, toUpdateEmployee.DateOfBirth);
            toUpdateEmployee.PhoneNumber = CustomUtilities.IsNullOrSecondValue<string>(employeeDto.PhoneNumber, toUpdateEmployee.PhoneNumber);
            toUpdateEmployee.Email = CustomUtilities.IsNullOrSecondValue<string>(employeeDto.Email, toUpdateEmployee.Email);
            toUpdateEmployee.Password = CustomUtilities.IsNullOrSecondValue<string>(employeeDto.Password, toUpdateEmployee.Password);
            toUpdateEmployee.Role = CustomUtilities.IsNullOrSecondValue<Int16>(employeeDto.Role, toUpdateEmployee.Role);

            var updatedEmployee = await _employeeRepository.UpdateAsync(toUpdateEmployee, loginName);
            var employeeResponse = _mapper.Map<EmployeeResponse>(updatedEmployee);

            return employeeResponse;
        }
    }
}
