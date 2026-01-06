using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.RestaurantEvents.Commands.UpdateRestaurantEvent
{
    public class UpdateRestaurantEventCommandHandler : IRequestHandler<UpdateRestaurantEventCommand>
    {
        private readonly IRestaurantEventRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRestaurantEventCommandHandler(IRestaurantEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task Handle(UpdateRestaurantEventCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<RestaurantEvent>(request);
            _repository.Update(value);
            return Task.CompletedTask;
        }
    }
}
