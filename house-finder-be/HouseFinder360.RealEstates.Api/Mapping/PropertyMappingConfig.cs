using HouseFinder360.RealEstates.Api.Dto.Requests.Property;
using HouseFinder360.RealEstates.Application.RealEstates.Commands;
using Mapster;

namespace HouseFinder360.RealEstates.Api.Mapping;

internal class PropertyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SalePropertyRequest, CreateSalePropertyCommand>();
    }
}