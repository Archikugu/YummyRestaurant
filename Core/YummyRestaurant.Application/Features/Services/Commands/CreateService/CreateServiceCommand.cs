using MediatR;
using YummyRestaurant.Application.DTOs.ServiceDTOs;

namespace YummyRestaurant.Application.Features.Services.Commands.CreateService;

public class CreateServiceCommand : IRequest
{
    public CreateServiceDto CreateServiceDto { get; set; }

    public CreateServiceCommand(CreateServiceDto createServiceDto)
    {
        CreateServiceDto = createServiceDto;
    }
}
