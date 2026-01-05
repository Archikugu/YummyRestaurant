using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ChefDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Chefs.Queries.GetChefById;

public class GetChefByIdQueryHandler : IRequestHandler<GetChefByIdQuery, GetByIdChefDto>
{
    private readonly IGenericRepository<Chef> _repository;
    private readonly IMapper _mapper;

    public GetChefByIdQueryHandler(IGenericRepository<Chef> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdChefDto> Handle(GetChefByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdChefDto>(value);
    }
}
