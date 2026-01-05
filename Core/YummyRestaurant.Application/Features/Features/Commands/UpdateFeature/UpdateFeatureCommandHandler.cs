using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Features.Commands.UpdateFeature;

public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IGenericRepository<Feature> _repository;
    private readonly IMapper _mapper;

    public UpdateFeatureCommandHandler(IGenericRepository<Feature> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = _mapper.Map<Feature>(request.UpdateFeatureDto);
        _repository.Update(feature);
        await Task.CompletedTask;
    }
}
