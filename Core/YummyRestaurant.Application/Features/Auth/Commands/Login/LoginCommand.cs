using MediatR;
using YummyRestaurant.Application.DTOs.Auth;

namespace YummyRestaurant.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<TokenResponseDto>
{
    public LoginDto LoginDto { get; set; }

    public LoginCommand(LoginDto loginDto)
    {
        LoginDto = loginDto;
    }
}
