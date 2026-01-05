using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.MessageDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Messages.Queries.GetMessageList;

public class GetMessageQueryHandler : IRequestHandler<GetMessageQuery, List<ResultMessageDto>>
{
    private readonly IGenericRepository<Message> _repository;
    private readonly IMapper _mapper;

    public GetMessageQueryHandler(IGenericRepository<Message> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultMessageDto>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultMessageDto>>(values);
    }
}
