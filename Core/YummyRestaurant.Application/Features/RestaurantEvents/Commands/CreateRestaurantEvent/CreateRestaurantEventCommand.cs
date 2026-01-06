using MediatR;

namespace YummyRestaurant.Application.Features.RestaurantEvents.Commands.CreateRestaurantEvent
{
    public class CreateRestaurantEventCommand : IRequest
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
    }
}
