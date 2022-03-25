using Employee.API.Helpers;
using Employee.Application.Commands;
using Employee.Application.Mappers;
using Employee.Application.Responses;
using Employee.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Employee.Application.Handlers
{
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

            if (employeeDto is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

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
