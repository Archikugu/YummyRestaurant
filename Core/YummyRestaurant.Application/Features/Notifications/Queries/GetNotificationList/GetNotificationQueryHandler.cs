using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.NotificationDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Notifications.Queries.GetNotificationList;

public class GetNotificationQueryHandler(IGenericRepository<Notification> _repository, IMapper _mapper) : IRequestHandler<GetNotificationQuery, List<ResultNotificationDto>>
{
    public async Task<List<ResultNotificationDto>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultNotificationDto>>(values);
    }
}
