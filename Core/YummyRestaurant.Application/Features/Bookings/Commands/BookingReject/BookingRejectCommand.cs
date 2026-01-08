using MediatR;

namespace YummyRestaurant.Application.Features.Bookings.Commands.BookingReject;

public class BookingRejectCommand : IRequest
{
    public int Id { get; set; }

    public BookingRejectCommand(int id)
    {
        Id = id;
    }
}
