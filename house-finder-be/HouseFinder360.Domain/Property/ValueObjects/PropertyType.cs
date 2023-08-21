using FluentResults;
using HouseFinder360.BuildingBlocks.BuildingBlocks;
using HouseFinder360.Domain.Property.Enums;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class PropertyType : ValueObject
{
    public TypeOfProperty TypeOfProperty { get; init; }
    public string? PropertyTypeDeclaration { get; init; }

    public string TypeOfPropertyToString()
    {
        return TypeOfProperty switch
        {
            TypeOfProperty.Apartment => "Apartment",
            TypeOfProperty.House => "House",
            TypeOfProperty.ResidentialPlace => "Residential Place",
            TypeOfProperty.Lot => "Lot",
            TypeOfProperty.Garage => "Garage",
            TypeOfProperty.Villa => "Villa",
            TypeOfProperty.Other => "Other",
            _ => throw new ArgumentOutOfRangeException($"Unknown type")
        };
    }

    public static Result<PropertyType> CreatePropertyType(TypeOfProperty typeOfProperty, string? propertyTypeDeclaration)
    {
        return new PropertyType(typeOfProperty, propertyTypeDeclaration);
    }

    private PropertyType(TypeOfProperty typeOfProperty, string? propertyTypeDeclaration)
    {
        TypeOfProperty = typeOfProperty;
        PropertyTypeDeclaration = propertyTypeDeclaration;
    }

    public static TypeOfProperty TypeOfPropertyToEnum(string type)
    {
        return type switch
        {
            "Apartment" => TypeOfProperty.Apartment,
            "House" => TypeOfProperty.House,
            "Residential Place" => TypeOfProperty.ResidentialPlace,
            "Lot" => TypeOfProperty.Lot,
            "Garage" => TypeOfProperty.Garage,
            "Villa" => TypeOfProperty.Villa,
            _ => TypeOfProperty.Other
        };
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return TypeOfProperty;
    }

    private PropertyType()
    {
        
    }
}