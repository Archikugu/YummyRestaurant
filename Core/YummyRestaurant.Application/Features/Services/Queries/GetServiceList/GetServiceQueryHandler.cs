using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ServiceDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Services.Queries.GetServiceList;

public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<ResultServiceDto>>
{
    private readonly IGenericRepository<Service> _repository;
    private readonly IMapper _mapper;

    public GetServiceQueryHandler(IGenericRepository<Service> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultServiceDto>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultServiceDto>>(values);
    }
}
