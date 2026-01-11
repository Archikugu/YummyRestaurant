using MediatR;
using YummyRestaurant.Application.DTOs.Auth;

namespace YummyRestaurant.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<bool>
{
    public RegisterDto RegisterDto { get; set; }

    public RegisterCommand(RegisterDto registerDto)
    {
        RegisterDto = registerDto;
    }
}
