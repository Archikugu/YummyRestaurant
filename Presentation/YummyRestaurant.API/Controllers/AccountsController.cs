using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.Auth;
using YummyRestaurant.Application.Features.Auth.Commands.Login;
using YummyRestaurant.Application.Features.Auth.Commands.Register;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        try
        {
            var result = await _mediator.Send(new LoginCommand(loginDto));
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _mediator.Send(new RegisterCommand(registerDto));
        if (result)
        {
            return Ok("Registration successful");
        }
        return BadRequest("Registration failed");
    }
}
