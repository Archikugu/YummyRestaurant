using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.FeatureDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Features.Queries.GetFeatureById;

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetByIdFeatureDto>
{
    private readonly IGenericRepository<Feature> _repository;
    private readonly IMapper _mapper;

    public GetFeatureByIdQueryHandler(IGenericRepository<Feature> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdFeatureDto> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdFeatureDto>(value);
    }
}
