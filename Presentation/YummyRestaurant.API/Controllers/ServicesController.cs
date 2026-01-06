using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.ServiceDTOs;
using YummyRestaurant.Application.Features.Services.Commands.CreateService;
using YummyRestaurant.Application.Features.Services.Commands.RemoveService;
using YummyRestaurant.Application.Features.Services.Commands.UpdateService;
using YummyRestaurant.Application.Features.Services.Queries.GetServiceById;
using YummyRestaurant.Application.Features.Services.Queries.GetServiceList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController(IMediator _mediator, IValidator<CreateServiceDto> _createValidator, IValidator<UpdateServiceDto> _updateValidator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetServiceQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetServiceByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceDto createServiceDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createServiceDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreateServiceCommand(createServiceDto));
        return Ok("Service successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveServiceCommand(id));
        return Ok("Service successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateServiceDto updateServiceDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updateServiceDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdateServiceCommand(updateServiceDto));
        return Ok("Service successfully updated");
    }
}
