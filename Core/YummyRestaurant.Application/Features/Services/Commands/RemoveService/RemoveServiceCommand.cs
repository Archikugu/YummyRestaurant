using MediatR;

namespace YummyRestaurant.Application.Features.Services.Commands.RemoveService;

public class RemoveServiceCommand : IRequest
{
    public int Id { get; set; }

    public RemoveServiceCommand(int id)
    {
        Id = id;
    }
}
