using FluentValidation;
using HouseFinder360.Application.Authentication.Commands.Register;

namespace HouseFinder360.Api.Validations;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(3, 20);
        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(3, 20);
    }
}