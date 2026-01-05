using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Features.Commands.CreateFeature;

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
{
    private readonly IGenericRepository<Feature> _repository;
    private readonly IMapper _mapper;

    public CreateFeatureCommandHandler(IGenericRepository<Feature> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = _mapper.Map<Feature>(request.CreateFeatureDto);
        await _repository.AddAsync(feature);
    }
}
