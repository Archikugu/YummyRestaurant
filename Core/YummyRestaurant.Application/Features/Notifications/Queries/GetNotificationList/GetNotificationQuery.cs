using MediatR;
using YummyRestaurant.Application.DTOs.NotificationDTOs;

namespace YummyRestaurant.Application.Features.Notifications.Queries.GetNotificationList;

public class GetNotificationQuery : IRequest<List<ResultNotificationDto>>
{
}
