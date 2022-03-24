using Employee.Application.Constants;
using FluentValidation;
using System;

namespace Employee.Application.Commands
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("First Name"))
                .MaximumLength(50).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_50("First Name"));

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Last Name"))
                .MaximumLength(50).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_50("Last Name"));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Email"))
                .MaximumLength(50).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_50("Email"));

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage(ConstantValidatorMessage.MESSAGE_IS_EMPTY("Date Of Birth"));

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(50).WithMessage(ConstantValidatorMessage.MESSAGE_MAX_LENGTH_10("Phone Number")); ;
        }
    }
}
