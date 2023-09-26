using FluentValidation;
using HouseFinder360.Users.Infrastructure.Features.Authentication.Commands.Register;

namespace HouseFinder360.Users.Infrastructure.Features.Authentication.Validations;

public class RegisterRequestValidator : AbstractValidator<RegisterCommand>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(3, 20);
        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(3, 20);
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}