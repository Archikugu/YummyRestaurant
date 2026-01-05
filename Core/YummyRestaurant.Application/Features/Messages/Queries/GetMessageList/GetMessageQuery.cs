using MediatR;
using YummyRestaurant.Application.DTOs.MessageDTOs;

namespace YummyRestaurant.Application.Features.Messages.Queries.GetMessageList;

public class GetMessageQuery : IRequest<List<ResultMessageDto>>
{
}
