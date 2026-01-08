using MediatR;

namespace YummyRestaurant.Application.Features.Bookings.Commands.BookingApprove;

public class BookingApproveCommand : IRequest
{
    public int Id { get; set; }

    public BookingApproveCommand(int id)
    {
        Id = id;
    }
}
