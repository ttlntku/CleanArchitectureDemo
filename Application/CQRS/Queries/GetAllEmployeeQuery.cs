﻿using Application.CQRS.Responses;
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
using AutoMapper;

namespace Application.CQRS.Queries
{
    public class GetAllEmployeeQuery : IRequest<IReadOnlyList<EmployeeResponse>>
    {
    }

    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IReadOnlyList<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<EmployeeResponse>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {

            List<EmployeeEntity> listEmployee = await _employeeRepository.GetAllAsync();
            IReadOnlyList<EmployeeResponse> listEmployeeResponse = listEmployee.Select(le => _mapper.Map<EmployeeResponse>(le)).ToList();

            return listEmployeeResponse;
        }
    }
}
