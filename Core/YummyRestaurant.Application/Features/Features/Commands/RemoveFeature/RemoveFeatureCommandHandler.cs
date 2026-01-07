using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Features.Commands.RemoveFeature;

public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
{
    private readonly IGenericRepository<Feature> _repository;

    public RemoveFeatureCommandHandler(IGenericRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
