using MediatR;

namespace YummyRestaurant.Application.Features.Notifications.Commands.RemoveNotification;

public class RemoveNotificationCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
