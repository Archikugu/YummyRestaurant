using MediatR;
using YummyRestaurant.Application.DTOs.ChefDTOs;

namespace YummyRestaurant.Application.Features.Chefs.Commands.UpdateChef;

public class UpdateChefCommand : IRequest
{
    public UpdateChefDto UpdateChefDto { get; set; }

    public UpdateChefCommand(UpdateChefDto updateChefDto)
    {
        UpdateChefDto = updateChefDto;
    }
}
