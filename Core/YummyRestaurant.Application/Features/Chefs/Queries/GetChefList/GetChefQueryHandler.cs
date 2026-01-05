using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ChefDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Chefs.Queries.GetChefList;

public class GetChefQueryHandler : IRequestHandler<GetChefQuery, List<ResultChefDto>>
{
    private readonly IGenericRepository<Chef> _repository;
    private readonly IMapper _mapper;

    public GetChefQueryHandler(IGenericRepository<Chef> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultChefDto>> Handle(GetChefQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultChefDto>>(values);
    }
}
