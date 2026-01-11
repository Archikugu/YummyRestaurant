using MediatR;
using Microsoft.AspNetCore.Identity;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.RegisterDto.Username) || 
            string.IsNullOrEmpty(request.RegisterDto.Email) || 
            string.IsNullOrEmpty(request.RegisterDto.Password))
        {
             return false;
        }

        var appUser = new AppUser
        {
            UserName = request.RegisterDto.Username,
            Email = request.RegisterDto.Email,
            Name = request.RegisterDto.Name,
            Surname = request.RegisterDto.Surname
        };

        var result = await _userManager.CreateAsync(appUser, request.RegisterDto.Password);

        return result.Succeeded;
    }
}
