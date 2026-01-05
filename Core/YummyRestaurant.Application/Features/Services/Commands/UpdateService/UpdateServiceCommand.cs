using MediatR;
using YummyRestaurant.Application.DTOs.ServiceDTOs;

namespace YummyRestaurant.Application.Features.Services.Commands.UpdateService;

public class UpdateServiceCommand : IRequest
{
    public UpdateServiceDto UpdateServiceDto { get; set; }

    public UpdateServiceCommand(UpdateServiceDto updateServiceDto)
    {
        UpdateServiceDto = updateServiceDto;
    }
}
