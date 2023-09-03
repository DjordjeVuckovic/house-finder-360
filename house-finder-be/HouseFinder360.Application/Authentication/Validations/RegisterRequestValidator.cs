﻿using FluentValidation;
using HouseFinder360.Application.Authentication.Commands.Register;

namespace HouseFinder360.Application.Authentication.Validations;

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