using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;
using YummyRestaurant.Domain.Enums;

namespace YummyRestaurant.Application.Features.Bookings.Commands.BookingReject;

public class BookingRejectCommandHandler : IRequestHandler<BookingRejectCommand>
{
    private readonly IGenericRepository<Booking> _repository;

    public BookingRejectCommandHandler(IGenericRepository<Booking> repository)
    {
        _repository = repository;
    }

    public async Task Handle(BookingRejectCommand request, CancellationToken cancellationToken)
    {
        var booking = await _repository.GetByIdAsync(request.Id);
        if (booking != null)
        {
            booking.BookingStatus = BookingStatus.Rejected;
            _repository.Update(booking);
        }
    }
}
