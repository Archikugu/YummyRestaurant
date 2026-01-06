using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.RestaurantEventDTOs;

namespace YummyRestaurant.Application.Features.RestaurantEvents.Queries.GetRestaurantEventList
{
    public class GetRestaurantEventQueryHandler : IRequestHandler<GetRestaurantEventQuery, List<ResultRestaurantEventDto>>
    {
        private readonly IRestaurantEventRepository _repository;
        private readonly IMapper _mapper;

        public GetRestaurantEventQueryHandler(IRestaurantEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultRestaurantEventDto>> Handle(GetRestaurantEventQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultRestaurantEventDto>>(values);
        }
    }
}
