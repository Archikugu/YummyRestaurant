using MediatR;
using YummyRestaurant.Application.DTOs.BookingDTOs;

namespace YummyRestaurant.Application.Features.Bookings.Commands.CreateBooking;

public class CreateBookingCommand : IRequest
{
    public CreateBookingDto CreateBookingDto { get; set; }

    public CreateBookingCommand(CreateBookingDto createBookingDto)
    {
        CreateBookingDto = createBookingDto;
    }
}
