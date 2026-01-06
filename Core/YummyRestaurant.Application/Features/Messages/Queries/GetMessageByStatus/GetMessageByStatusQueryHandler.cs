using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.MessageDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Messages.Queries.GetMessageByStatus;

public class GetMessageByStatusQueryHandler(IGenericRepository<Message> _repository, IMapper _mapper) : IRequestHandler<GetMessageByStatusQuery, List<ResultMessageDto>>
{
    public async Task<List<ResultMessageDto>> Handle(GetMessageByStatusQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetFilteredListAsync(x => x.IsRead == request.IsRead);
        return _mapper.Map<List<ResultMessageDto>>(values);
    }
}
