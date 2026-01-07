using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.AboutDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Abouts.Queries.GetAboutById;

public class GetAboutByIdQueryHandler(IGenericRepository<About> _repository, IMapper _mapper) : IRequestHandler<GetAboutByIdQuery, GetByIdAboutDto>
{
    public async Task<GetByIdAboutDto> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdAboutDto>(values);
    }
}
