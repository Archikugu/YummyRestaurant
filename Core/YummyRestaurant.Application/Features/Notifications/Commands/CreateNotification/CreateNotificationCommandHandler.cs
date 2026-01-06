using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.NotificationDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Notifications.Commands.CreateNotification;

public class CreateNotificationCommandHandler(IGenericRepository<Notification> _repository, IMapper _mapper) : IRequestHandler<CreateNotificationCommand>
{
    public async Task Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        var value = _mapper.Map<Notification>(request.CreateNotificationDto);
        value.Date = DateTime.Now; 
        value.IsRead = false;
        await _repository.AddAsync(value);
    }
}
