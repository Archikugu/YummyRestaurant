using MediatR;
using YummyRestaurant.Application.DTOs.NotificationDTOs;

namespace YummyRestaurant.Application.Features.Notifications.Queries.GetNotificationByStatus;

public class GetNotificationByStatusQuery(bool isRead) : IRequest<List<ResultNotificationDto>>
{
    public bool IsRead { get; set; } = isRead;
}
