using MediatR;
using YummyRestaurant.Application.DTOs.NotificationDTOs;

namespace YummyRestaurant.Application.Features.Notifications.Commands.UpdateNotification;

public class UpdateNotificationCommand(UpdateNotificationDto updateNotificationDto) : IRequest
{
    public UpdateNotificationDto UpdateNotificationDto { get; set; } = updateNotificationDto;
}
