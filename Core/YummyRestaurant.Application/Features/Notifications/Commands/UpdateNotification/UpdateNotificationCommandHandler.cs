using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Notifications.Commands.UpdateNotification;

public class UpdateNotificationCommandHandler(IGenericRepository<Notification> _repository, IMapper _mapper) : IRequestHandler<UpdateNotificationCommand>
{
    public async Task Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
    {
        var value = _mapper.Map<Notification>(request.UpdateNotificationDto);
        _repository.Update(value);
    }
}
