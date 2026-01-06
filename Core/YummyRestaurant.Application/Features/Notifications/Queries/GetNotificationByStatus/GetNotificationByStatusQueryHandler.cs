using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.NotificationDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Notifications.Queries.GetNotificationByStatus;

public class GetNotificationByStatusQueryHandler(IGenericRepository<Notification> _repository, IMapper _mapper) : IRequestHandler<GetNotificationByStatusQuery, List<ResultNotificationDto>>
{
    public async Task<List<ResultNotificationDto>> Handle(GetNotificationByStatusQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetFilteredListAsync(x => x.IsRead == request.IsRead);
        return _mapper.Map<List<ResultNotificationDto>>(values);
    }
}
