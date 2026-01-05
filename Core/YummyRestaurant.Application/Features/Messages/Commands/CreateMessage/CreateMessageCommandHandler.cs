using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Messages.Commands.CreateMessage;

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand>
{
    private readonly IGenericRepository<Message> _repository;
    private readonly IMapper _mapper;

    public CreateMessageCommandHandler(IGenericRepository<Message> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = _mapper.Map<Message>(request.CreateMessageDto);
        await _repository.AddAsync(message);
    }
}
