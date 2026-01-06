using MediatR;
using YummyRestaurant.Application.DTOs.RestaurantEventDTOs;

namespace YummyRestaurant.Application.Features.RestaurantEvents.Queries.GetRestaurantEventById
{
    public class GetRestaurantEventByIdQuery : IRequest<GetByIdRestaurantEventDto>
    {
        public int Id { get; set; }

        public GetRestaurantEventByIdQuery(int id)
        {
            Id = id;
        }
    }
}
