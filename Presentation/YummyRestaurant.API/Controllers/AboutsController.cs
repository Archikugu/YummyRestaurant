using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.Application.DTOs.AboutDTOs;
using YummyRestaurant.Application.Features.Abouts.Commands.CreateAbout;
using YummyRestaurant.Application.Features.Abouts.Commands.RemoveAbout;
using YummyRestaurant.Application.Features.Abouts.Commands.UpdateAbout;
using YummyRestaurant.Application.Features.Abouts.Queries.GetAboutById;
using YummyRestaurant.Application.Features.Abouts.Queries.GetAboutList;

namespace YummyRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
        var values = await _mediator.Send(new GetAboutListQuery());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
    {
        await _mediator.Send(new CreateAboutCommand(createAboutDto));
        return Ok("Hakkımızda alanı başarıyla eklendi");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAbout(int id)
    {
        await _mediator.Send(new RemoveAboutCommand(id));
        return Ok("Hakkımızda alanı başarıyla silindi");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAbout(int id)
    {
        var values = await _mediator.Send(new GetAboutByIdQuery(id));
        return Ok(values);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        await _mediator.Send(new UpdateAboutCommand(updateAboutDto));
        return Ok("Hakkımızda alanı başarıyla güncellendi");
    }
}
