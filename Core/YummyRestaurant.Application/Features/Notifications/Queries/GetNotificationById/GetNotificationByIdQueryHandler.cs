using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.NotificationDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Notifications.Queries.GetNotificationById;

public class GetNotificationByIdQueryHandler(IGenericRepository<Notification> _repository, IMapper _mapper) : IRequestHandler<GetNotificationByIdQuery, ResultNotificationDto>
{
    public async Task<ResultNotificationDto> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<ResultNotificationDto>(value);
    }
}
