using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ServiceDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Services.Queries.GetServiceById;

public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetByIdServiceDto>
{
    private readonly IGenericRepository<Service> _repository;
    private readonly IMapper _mapper;

    public GetServiceByIdQueryHandler(IGenericRepository<Service> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdServiceDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdServiceDto>(value);
    }
}
