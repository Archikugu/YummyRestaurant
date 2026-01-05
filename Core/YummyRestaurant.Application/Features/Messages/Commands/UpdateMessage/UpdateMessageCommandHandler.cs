using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Messages.Commands.UpdateMessage;

public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand>
{
    private readonly IGenericRepository<Message> _repository;
    private readonly IMapper _mapper;

    public UpdateMessageCommandHandler(IGenericRepository<Message> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = _mapper.Map<Message>(request.UpdateMessageDto);
        _repository.Update(message);
        await Task.CompletedTask;
    }
}
