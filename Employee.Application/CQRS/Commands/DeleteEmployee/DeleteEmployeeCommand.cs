using Employee.Application.Constants;
using Employee.Application.Mappers;
using Employee.Core.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.CQRS.Commands.DeleteEmployee
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

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employeeDto = MapperConfig.mapper.Map<DeleteEmployeeCommand>(request);

                Employee.Core.Entities.Employee _employeeEntity = new Employee.Core.Entities.Employee()
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
