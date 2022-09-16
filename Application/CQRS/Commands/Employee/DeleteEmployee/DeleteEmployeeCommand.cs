using Application.Constants;
using Core.Repositories;
using Application.Mappers;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using AutoMapper;

namespace Application.CQRS.Commands.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Id"));
        }
    }

    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employeeDto = _mapper.Map<DeleteEmployeeCommand>(request);

                EmployeeEntity _employeeEntity = new EmployeeEntity()
                {
                    Id = employeeDto.Id
                };

                await _employeeRepository.DeleteAsync(_employeeEntity);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
