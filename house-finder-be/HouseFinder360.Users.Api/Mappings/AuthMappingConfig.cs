using HouseFinder360.Users.Api.Dto.Requests;
using HouseFinder360.Users.Infrastructure.Features.Authentication.Commands.Register;
using Mapster;

namespace HouseFinder360.Users.Api.Mappings;

public class AuthMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}