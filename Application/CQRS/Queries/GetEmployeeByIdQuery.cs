using Application.CQRS.Responses;
using Application.Mappers;
using Core.Entities;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
    {
        public int Id { get; set; }
        public GetEmployeeByIdQuery(int id) { this.Id = id; }
    }

    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {

            EmployeeEntity foundEmployee = await _employeeRepository.GetByIdAsync(request.Id);
            var employeeResponse = MapperConfig.mapper.Map<EmployeeResponse>(foundEmployee);


            return employeeResponse;
        }
    }
}
