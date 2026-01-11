using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.Auth;
using YummyRestaurant.Application.Features.Auth.Commands.Login;
using YummyRestaurant.Application.Features.Auth.Commands.Register;

namespace YummyRestaurant.WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _mediator.Send(new RegisterCommand(registerDto));
        if (result)
        {
            return Ok("User created successfully");
        }
        return BadRequest("User creation failed");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try 
        {
             var result = await _mediator.Send(new LoginCommand(loginDto));
             return Ok(result);
        }
        catch (Exception ex)
        {
             return Unauthorized(ex.Message);
        }
    }
}
