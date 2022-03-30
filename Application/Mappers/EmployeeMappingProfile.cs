using Application.CQRS.Commands.Employee.CreateEmployee;
using Application.CQRS.Commands.Employee.DeleteEmployee;
using Application.CQRS.Commands.Employee.UpdateEmployee;
using Application.CQRS.Commands.Login;
using Application.CQRS.Responses;
using AutoMapper;
using Core.Entities;

namespace Application.Mappers
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            //configure mapping profile for employee
            CreateMap<EmployeeEntity, EmployeeResponse>().ReverseMap();

            CreateMap<CreateEmployeeCommandDto, CreateEmployeeCommand>().ReverseMap();
            CreateMap<UpdateEmployeeCommandDto, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<DeleteEmployeeCommandDto, DeleteEmployeeCommand>().ReverseMap();
            CreateMap<LoginCommandDto, LoginCommand>().ReverseMap();
        }
    }
}
