using MediatR;
using YummyRestaurant.Application.DTOs.NotificationDTOs;

namespace YummyRestaurant.Application.Features.Notifications.Commands.CreateNotification;

public class CreateNotificationCommand(CreateNotificationDto createNotificationDto) : IRequest
{
    public CreateNotificationDto CreateNotificationDto { get; set; } = createNotificationDto;
}
