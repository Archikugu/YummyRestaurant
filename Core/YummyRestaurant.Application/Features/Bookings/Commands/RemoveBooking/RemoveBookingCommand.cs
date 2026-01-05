using MediatR;

namespace YummyRestaurant.Application.Features.Bookings.Commands.RemoveBooking;

public class RemoveBookingCommand : IRequest
{
    public int Id { get; set; }

    public RemoveBookingCommand(int id)
    {
        Id = id;
    }
}
