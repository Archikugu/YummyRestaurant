using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.FeatureDTOs;
using YummyRestaurant.Application.Features.Features.Commands.CreateFeature;
using YummyRestaurant.Application.Features.Features.Commands.RemoveFeature;
using YummyRestaurant.Application.Features.Features.Commands.UpdateFeature;
using YummyRestaurant.Application.Features.Features.Queries.GetFeatureById;
using YummyRestaurant.Application.Features.Features.Queries.GetFeatureList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController(IMediator _mediator, IValidator<CreateFeatureDto> _createValidator, IValidator<UpdateFeatureDto> _updateValidator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetFeatureQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetFeatureByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFeatureDto createFeatureDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createFeatureDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreateFeatureCommand(createFeatureDto));
        return Ok("Feature successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveFeatureCommand(id));
        return Ok("Feature successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFeatureDto updateFeatureDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updateFeatureDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdateFeatureCommand(updateFeatureDto));
        return Ok("Feature successfully updated");
    }
}
