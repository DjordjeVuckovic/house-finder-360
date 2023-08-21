using HouseFinder360.Api.Dto.Requests.Property;
using HouseFinder360.Application.Property.Commands;
using Mapster;

namespace HouseFinder360.Api.Mapping;

public class PropertyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SalePropertyRequest, CreateSalePropertyCommand>();
    }
}