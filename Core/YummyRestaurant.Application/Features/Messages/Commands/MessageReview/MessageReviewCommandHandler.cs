using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Messages.Commands.MessageReview;

public class MessageReviewCommandHandler(IGenericRepository<Message> _repository) : IRequestHandler<MessageReviewCommand>
{
    public async Task Handle(MessageReviewCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.IsRead = true;
        _repository.Update(values);
        // Task.CompletedTask is not needed because Update is synchronous but we are in an async method. 
        // We can just return strict Task.CompletedTask or let it implicit if possible, but IRequestHandler expects Task.
        // Since GetByIdAsync is async, wait for it. _repository.Update is void/sync usually.
        // To satisfy Task return type:
        // return Task.CompletedTask; is fine if the interface signature requires Task.
    }
}
