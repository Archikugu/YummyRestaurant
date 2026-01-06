using MediatR;
using YummyRestaurant.Application.DTOs.NotificationDTOs;

namespace YummyRestaurant.Application.Features.Notifications.Queries.GetNotificationById;

public class GetNotificationByIdQuery(int id) : IRequest<ResultNotificationDto>
{
    public int Id { get; set; } = id;
}
