using MediatR;
using YummyRestaurant.Application.DTOs.MessageDTOs;

namespace YummyRestaurant.Application.Features.Messages.Queries.GetMessageById;

public class GetMessageByIdQuery : IRequest<GetByIdMessageDto>
{
    public int Id { get; set; }

    public GetMessageByIdQuery(int id)
    {
        Id = id;
    }
}
