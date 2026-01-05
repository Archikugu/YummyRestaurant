using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.FeatureDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Features.Queries.GetFeatureList;

public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<ResultFeatureDto>>
{
    private readonly IGenericRepository<Feature> _repository;
    private readonly IMapper _mapper;

    public GetFeatureQueryHandler(IGenericRepository<Feature> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultFeatureDto>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultFeatureDto>>(values);
    }
}
