using Application.Constants;
using Application.CQRS.Responses;
using Application.Delegates;
using Application.Mappers;
using Core.Entities;
using Core.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Employee.ExportEmployee
{
    public class ExportEmployeeCommand : IRequest<MemoryStream>
    {
        public Constant.EnumPrint PrintType { get; set; }
        public ExportEmployeeCommand(Constant.EnumPrint printType)
        {
            PrintType = printType;
        }
    }

    public class ExportEmployeeCommandValidator : AbstractValidator<ExportEmployeeCommand>
    {
        public ExportEmployeeCommandValidator()
        {
            RuleFor(x => x.PrintType)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("PrintType"));
        }
    }

    public class ExportEmployeeHandler : IRequestHandler<ExportEmployeeCommand, MemoryStream>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ExportEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<MemoryStream> Handle(ExportEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var memStream = new MemoryStream();
                List<EmployeeEntity> listEmployee = await _employeeRepository.GetAllAsync();

                if (request.PrintType.Equals(Constant.EnumPrint.xlsx))
                {
                    PrintDelegate.print<EmployeeEntity> printXlsx = PrintDelegate.ExportToXlsx<EmployeeEntity>;
                    memStream = printXlsx(listEmployee);
                }
                else if (request.PrintType.Equals(Constant.EnumPrint.csv))
                {
                    PrintDelegate.print<EmployeeEntity> printCsv = PrintDelegate.ExportToCSV<EmployeeEntity>;
                    memStream = printCsv(listEmployee);
                }

                return memStream;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
