using MediatR;

namespace YummyRestaurant.Application.Features.RestaurantEvents.Commands.RemoveRestaurantEvent
{
    public class RemoveRestaurantEventCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveRestaurantEventCommand(int id)
        {
            Id = id;
        }
    }
}
