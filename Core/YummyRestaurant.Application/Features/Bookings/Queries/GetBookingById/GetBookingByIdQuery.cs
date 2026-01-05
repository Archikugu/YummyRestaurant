using MediatR;
using YummyRestaurant.Application.DTOs.BookingDTOs;

namespace YummyRestaurant.Application.Features.Bookings.Queries.GetBookingById;

public class GetBookingByIdQuery : IRequest<GetByIdBookingDto>
{
    public int Id { get; set; }

    public GetBookingByIdQuery(int id)
    {
        Id = id;
    }
}
