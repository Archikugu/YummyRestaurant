using MediatR;
using YummyRestaurant.Application.DTOs.BookingDTOs;

namespace YummyRestaurant.Application.Features.Bookings.Queries.GetBookingList;

public class GetBookingQuery : IRequest<List<ResultBookingDto>>
{
}
