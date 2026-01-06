using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.RestaurantEventDTOs;

namespace YummyRestaurant.Application.Features.RestaurantEvents.Queries.GetRestaurantEventById
{
    public class GetRestaurantEventByIdQueryHandler : IRequestHandler<GetRestaurantEventByIdQuery, GetByIdRestaurantEventDto>
    {
        private readonly IRestaurantEventRepository _repository;
        private readonly IMapper _mapper;

        public GetRestaurantEventByIdQueryHandler(IRestaurantEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdRestaurantEventDto> Handle(GetRestaurantEventByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdRestaurantEventDto>(value);
        }
    }
}
