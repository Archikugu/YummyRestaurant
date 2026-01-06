using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;
using YummyRestaurant.Application.Features.PhotoGalleries.Commands.CreatePhotoGallery;
using YummyRestaurant.Application.Features.PhotoGalleries.Commands.RemovePhotoGallery;
using YummyRestaurant.Application.Features.PhotoGalleries.Commands.UpdatePhotoGallery;
using YummyRestaurant.Application.Features.PhotoGalleries.Queries.GetPhotoGalleryById;
using YummyRestaurant.Application.Features.PhotoGalleries.Queries.GetPhotoGalleryList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhotoGalleriesController(IMediator _mediator, IValidator<CreatePhotoGalleryDto> _createValidator, IValidator<UpdatePhotoGalleryDto> _updateValidator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var values = await _mediator.Send(new GetPhotoGalleryQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var value = await _mediator.Send(new GetPhotoGalleryByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePhotoGalleryDto createPhotoGalleryDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createPhotoGalleryDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new CreatePhotoGalleryCommand(createPhotoGalleryDto));
        return Ok("Photo successfully added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemovePhotoGalleryCommand(id));
        return Ok("Photo successfully deleted");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePhotoGalleryDto updatePhotoGalleryDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(updatePhotoGalleryDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _mediator.Send(new UpdatePhotoGalleryCommand(updatePhotoGalleryDto));
        return Ok("Photo successfully updated");
    }
}
