using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Messages.Commands.RemoveMessage;

public class RemoveMessageCommandHandler : IRequestHandler<RemoveMessageCommand>
{
    private readonly IGenericRepository<Message> _repository;

    public RemoveMessageCommandHandler(IGenericRepository<Message> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
