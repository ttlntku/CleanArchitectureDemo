﻿using Employee.API.Helpers;
using Employee.Application.Constants;
using Employee.Application.CQRS.Responses;
using Employee.Application.Mappers;
using Employee.Core.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.CQRS.Commands.UpdateEmployee
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

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeDto = MapperConfig.mapper.Map<UpdateEmployeeCommandDto>(request);

            var toUpdateEmployee = await _employeeRepository.GetByIdAsync(employeeDto.Id);

            if (toUpdateEmployee is null)
            {
                return null;
            }

            Employee.Core.Entities.Employee _employeeEntity = new Employee.Core.Entities.Employee()
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                DateOfBirth = employeeDto.DateOfBirth,
                PhoneNumber = employeeDto.PhoneNumber,
                Email = employeeDto.Email,
                Password = employeeDto.Password,
                UpdatedBy = "KIEU",
                UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now)
             };

            var updatedEmployee = await _employeeRepository.UpdateAsync(_employeeEntity);
            var employeeResponse = MapperConfig.mapper.Map<EmployeeResponse>(updatedEmployee);

            return employeeResponse;
        }
    }
}
