using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.ChefDTOs;
using YummyRestaurant.Application.Features.Chefs.Commands.CreateChef;
using YummyRestaurant.Application.Features.Chefs.Commands.RemoveChef;
using YummyRestaurant.Application.Features.Chefs.Commands.UpdateChef;
using YummyRestaurant.Application.Features.Chefs.Queries.GetChefById;
using YummyRestaurant.Application.Features.Chefs.Queries.GetChefList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChefsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateChefDto> _createValidator;
    private readonly IValidator<UpdateChefDto> _updateValidator;

    public ChefsController(IMediator mediator, IValidator<CreateChefDto> createValidator, IValidator<UpdateChefDto> updateValidator)
    {
        _mediator = mediator;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetChefQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetChefByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateChefDto createChefDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createChefDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreateChefCommand(createChefDto));
        return Ok("Chef successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveChefCommand(id));
        return Ok("Chef successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateChefDto updateChefDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updateChefDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdateChefCommand(updateChefDto));
        return Ok("Chef successfully updated");
    }
}
