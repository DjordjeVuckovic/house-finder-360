using HouseFinder360.Api.Dto.Requests.Auth;
using HouseFinder360.Application.Authentication.Commands.Register;
using Mapster;

namespace HouseFinder360.Api.Mapping;

public class AuthMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}