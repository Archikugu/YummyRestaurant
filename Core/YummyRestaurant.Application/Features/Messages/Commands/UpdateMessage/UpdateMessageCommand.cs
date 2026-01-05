using MediatR;
using YummyRestaurant.Application.DTOs.MessageDTOs;

namespace YummyRestaurant.Application.Features.Messages.Commands.UpdateMessage;

public class UpdateMessageCommand : IRequest
{
    public UpdateMessageDto UpdateMessageDto { get; set; }

    public UpdateMessageCommand(UpdateMessageDto updateMessageDto)
    {
        UpdateMessageDto = updateMessageDto;
    }
}
