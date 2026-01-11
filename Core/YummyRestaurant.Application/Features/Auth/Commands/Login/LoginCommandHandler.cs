using MediatR;
using Microsoft.AspNetCore.Identity;
using YummyRestaurant.Application.DTOs.Auth;
using YummyRestaurant.Application.Interfaces;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler(UserManager<AppUser> _userManager, IJwtService _jwtService) : IRequestHandler<LoginCommand, TokenResponseDto>
{

    public async Task<TokenResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.LoginDto.Username) || string.IsNullOrEmpty(request.LoginDto.Password))
             throw new Exception("Username or password required");

        var user = await _userManager.FindByNameAsync(request.LoginDto.Username) 
            ?? throw new Exception("Username or password incorrect");

        var checkPassword = await _userManager.CheckPasswordAsync(user, request.LoginDto.Password);
        if (!checkPassword) 
        {
             throw new Exception("Username or password incorrect");
        }

        return _jwtService.GenerateToken(user);
    }
}
