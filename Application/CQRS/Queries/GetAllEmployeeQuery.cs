using Application.CQRS.Responses;
using Core.Repositories;
using Application.Mappers;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Application.Delegates;
using System.Text.Json;

namespace Application.CQRS.Queries
{
    public class GetAllEmployeeQuery : IRequest<IReadOnlyList<EmployeeResponse>>
    {
    }

    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IReadOnlyList<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IReadOnlyList<EmployeeResponse>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {

            List<EmployeeEntity> listEmployee = await _employeeRepository.GetAllAsync();
            IReadOnlyList<EmployeeResponse> listEmployeeResponse = listEmployee.Select(le => MapperConfig.mapper.Map<EmployeeResponse>(le)).ToList();

            PrintDelegate.print<List<EmployeeEntity>> printDelegate = new PrintDelegate.print<List<EmployeeEntity>>(PrintDelegate.ExportToJson);
            printDelegate(listEmployee);
            PrintDelegate.print<List<EmployeeEntity>> printDelegate2 = new PrintDelegate.print<List<EmployeeEntity>>(PrintDelegate.ExportToXlsx);
            printDelegate2(listEmployee);

            return listEmployeeResponse;
        }
    }
}
