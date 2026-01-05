using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.MessageDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Messages.Queries.GetMessageById;

public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, GetByIdMessageDto>
{
    private readonly IGenericRepository<Message> _repository;
    private readonly IMapper _mapper;

    public GetMessageByIdQueryHandler(IGenericRepository<Message> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdMessageDto> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdMessageDto>(value);
    }
}
