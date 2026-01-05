using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Services.Commands.RemoveService;

public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
{
    private readonly IGenericRepository<Service> _repository;

    public RemoveServiceCommandHandler(IGenericRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        _repository.Remove(value);
    }
}
