using MediatR;
using YummyRestaurant.Application.DTOs.ChefDTOs;

namespace YummyRestaurant.Application.Features.Chefs.Commands.CreateChef;

public class CreateChefCommand : IRequest
{
    public CreateChefDto CreateChefDto { get; set; }

    public CreateChefCommand(CreateChefDto createChefDto)
    {
        CreateChefDto = createChefDto;
    }
}
