using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.RestaurantEvents.Commands.CreateRestaurantEvent
{
    public class CreateRestaurantEventCommandHandler : IRequestHandler<CreateRestaurantEventCommand>
    {
        private readonly IRestaurantEventRepository _repository;
        private readonly IMapper _mapper;

        public CreateRestaurantEventCommandHandler(IRestaurantEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateRestaurantEventCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<RestaurantEvent>(request);
            await _repository.AddAsync(value);
        }
    }
}
