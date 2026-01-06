using MediatR;
using YummyRestaurant.Application.DTOs.MessageDTOs;

namespace YummyRestaurant.Application.Features.Messages.Queries.GetMessageByStatus;

public class GetMessageByStatusQuery(bool isRead) : IRequest<List<ResultMessageDto>>
{
    public bool IsRead { get; set; } = isRead;
}
