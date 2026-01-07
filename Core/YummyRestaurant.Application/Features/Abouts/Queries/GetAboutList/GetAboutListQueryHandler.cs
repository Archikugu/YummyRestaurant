using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.AboutDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Abouts.Queries.GetAboutList;

public class GetAboutListQueryHandler(IGenericRepository<About> _repository, IMapper _mapper) : IRequestHandler<GetAboutListQuery, List<ResultAboutDto>>
{
    public async Task<List<ResultAboutDto>> Handle(GetAboutListQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultAboutDto>>(values);
    }
}
