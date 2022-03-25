using AutoMapper;
using Employee.Application.CQRS.Commands.CreateEmployee;
using Employee.Application.CQRS.Commands.DeleteEmployee;
using Employee.Application.CQRS.Commands.UpdateEmployee;
using Employee.Application.CQRS.Responses;

namespace Employee.Application.Mappers
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            //configure mapping profile for employee
            CreateMap<Employee.Core.Entities.Employee, EmployeeResponse>().ReverseMap();

            CreateMap<CreateEmployeeCommandDto, CreateEmployeeCommand>().ReverseMap();
            CreateMap<UpdateEmployeeCommandDto, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<DeleteEmployeeCommandDto, DeleteEmployeeCommand>().ReverseMap();
        }
    }
}
