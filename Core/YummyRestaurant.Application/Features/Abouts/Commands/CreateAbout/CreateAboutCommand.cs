using MediatR;
using YummyRestaurant.Application.DTOs.AboutDTOs;

namespace YummyRestaurant.Application.Features.Abouts.Commands.CreateAbout;

public class CreateAboutCommand(CreateAboutDto createAboutDto) : IRequest
{
    public CreateAboutDto CreateAboutDto { get; set; } = createAboutDto;
}
