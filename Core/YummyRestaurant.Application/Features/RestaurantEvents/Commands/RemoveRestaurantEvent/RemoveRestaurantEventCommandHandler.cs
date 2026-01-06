using MediatR;
using YummyRestaurant.Application.Abstract;

namespace YummyRestaurant.Application.Features.RestaurantEvents.Commands.RemoveRestaurantEvent
{
    public class RemoveRestaurantEventCommandHandler : IRequestHandler<RemoveRestaurantEventCommand>
    {
        private readonly IRestaurantEventRepository _repository;

        public RemoveRestaurantEventCommandHandler(IRestaurantEventRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRestaurantEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity != null)
            {
                _repository.Remove(entity);
            }
        }
    }
}
