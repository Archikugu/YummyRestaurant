using MediatR;
using YummyRestaurant.Application.DTOs.MessageDTOs;

namespace YummyRestaurant.Application.Features.Messages.Commands.CreateMessage;

public class CreateMessageCommand : IRequest
{
    public CreateMessageDto CreateMessageDto { get; set; }

    public CreateMessageCommand(CreateMessageDto createMessageDto)
    {
        CreateMessageDto = createMessageDto;
    }
}
