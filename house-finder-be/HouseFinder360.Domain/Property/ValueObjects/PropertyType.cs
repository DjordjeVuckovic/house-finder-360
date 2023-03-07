using HouseFinder360.Domain.Property.Enums;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class PropertyType
{
    public TypeOfProperty TypeOfProperty { get; private set; }
    public string PropertyTypeDeclaration { get; private set; } = null!;

    public PropertyType(TypeOfProperty typeOfProperty, string propertyTypeDeclaration)
    {
        TypeOfProperty = typeOfProperty;
        PropertyTypeDeclaration = propertyTypeDeclaration;
    }

    private PropertyType()
    {
    }
}