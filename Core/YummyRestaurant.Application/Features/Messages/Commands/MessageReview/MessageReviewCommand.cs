using MediatR;

namespace YummyRestaurant.Application.Features.Messages.Commands.MessageReview;

public class MessageReviewCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
