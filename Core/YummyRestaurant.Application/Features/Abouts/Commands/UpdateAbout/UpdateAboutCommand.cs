using MediatR;
using YummyRestaurant.Application.DTOs.AboutDTOs;

namespace YummyRestaurant.Application.Features.Abouts.Commands.UpdateAbout;

public class UpdateAboutCommand(UpdateAboutDto updateAboutDto) : IRequest
{
    public UpdateAboutDto UpdateAboutDto { get; set; } = updateAboutDto;
}
