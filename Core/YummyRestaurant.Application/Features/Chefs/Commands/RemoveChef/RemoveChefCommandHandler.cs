using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Chefs.Commands.RemoveChef;

public class RemoveChefCommandHandler : IRequestHandler<RemoveChefCommand>
{
    private readonly IGenericRepository<Chef> _repository;

    public RemoveChefCommandHandler(IGenericRepository<Chef> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveChefCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
