using Employee.Application.Mappers;
using Employee.Application.Queries;
using Employee.Application.Responses;
using Employee.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Handlers
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IReadOnlyList<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IReadOnlyList<EmployeeResponse>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            List<Employee.Core.Entities.Employee> listEmployee = await _employeeRepository.GetAllAsync();
            IReadOnlyList<EmployeeResponse> listEmployeeResponse = listEmployee.Select(le => EmployeeMapper.mapper.Map<EmployeeResponse>(le)).ToList();

            return listEmployeeResponse;
        }
    }
}
