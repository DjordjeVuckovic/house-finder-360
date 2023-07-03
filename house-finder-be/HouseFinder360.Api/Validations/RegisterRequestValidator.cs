using FluentValidation;
using HouseFinder360.Api.Dto.Requests.Auth;
using HouseFinder360.Application.Authentication.Commands.Register;

namespace HouseFinder360.Api.Validations;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
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