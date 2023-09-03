using FluentValidation;
using HouseFinder360.RealEstates.Application.RealEstates.Commands;

namespace HouseFinder360.RealEstates.Application.RealEstates.Validators;

public class SalePropertyValidator : AbstractValidator<CreateSalePropertyCommand>
{
    public SalePropertyValidator()
    {
        RuleFor(x => x.Price > 0);
    }
}