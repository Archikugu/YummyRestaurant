using MediatR;

namespace YummyRestaurant.Application.Features.Messages.Commands.RemoveMessage;

public class RemoveMessageCommand : IRequest
{
    public int Id { get; set; }

    public RemoveMessageCommand(int id)
    {
        Id = id;
    }
}
