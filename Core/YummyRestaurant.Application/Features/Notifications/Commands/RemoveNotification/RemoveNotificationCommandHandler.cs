using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Notifications.Commands.RemoveNotification;

public class RemoveNotificationCommandHandler(IGenericRepository<Notification> _repository) : IRequestHandler<RemoveNotificationCommand>
{
    public async Task Handle(RemoveNotificationCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
