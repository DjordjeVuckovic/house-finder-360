using FluentValidation;
using HouseFinder360.Application.Property.Commands;

namespace HouseFinder360.Application.Property.Validators;

public class SalePropertyValidator : AbstractValidator<CreateSalePropertyCommand>
{
    public SalePropertyValidator()
    {
        RuleFor(x => x.Price > 0);
    }
}