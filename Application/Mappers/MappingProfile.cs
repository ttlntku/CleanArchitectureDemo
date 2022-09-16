using Application.CQRS.Commands.Employee.CreateEmployee;
using Application.CQRS.Commands.Employee.DeleteEmployee;
using Application.CQRS.Commands.Employee.UpdateEmployee;
using Application.CQRS.Commands.Login;
using Application.CQRS.Responses;
using AutoMapper;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //configure mapping profile for employee
            CreateMap<EmployeeEntity, EmployeeResponse>().ReverseMap();
            CreateMap<EmployeeEntity, EmployeeParam>().ReverseMap();
            CreateMap<CreateEmployeeCommandDto, CreateEmployeeCommand>().ReverseMap();
            CreateMap<UpdateEmployeeCommandDto, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<DeleteEmployeeCommandDto, DeleteEmployeeCommand>().ReverseMap();
            CreateMap<LoginCommandDto, LoginCommand>().ReverseMap();

            CreateMap<FactoryEntity, FactoryResponse>().ReverseMap();
            CreateMap<FactoryEntity, FactoryParam>().ReverseMap();
        }
    }
}
