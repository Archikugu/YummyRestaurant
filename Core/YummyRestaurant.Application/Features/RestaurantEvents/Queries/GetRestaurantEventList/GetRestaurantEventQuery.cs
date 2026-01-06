using MediatR;
using YummyRestaurant.Application.DTOs.RestaurantEventDTOs;

namespace YummyRestaurant.Application.Features.RestaurantEvents.Queries.GetRestaurantEventList
{
    public class GetRestaurantEventQuery : IRequest<List<ResultRestaurantEventDto>>
    {
    }
}
