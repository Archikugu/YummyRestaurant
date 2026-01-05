using MediatR;
using YummyRestaurant.Application.DTOs.BookingDTOs;

namespace YummyRestaurant.Application.Features.Bookings.Commands.UpdateBooking;

public class UpdateBookingCommand : IRequest
{
    public UpdateBookingDto UpdateBookingDto { get; set; }

    public UpdateBookingCommand(UpdateBookingDto updateBookingDto)
    {
        UpdateBookingDto = updateBookingDto;
    }
}
