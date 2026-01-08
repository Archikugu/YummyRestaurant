using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;
using YummyRestaurant.Domain.Enums;

namespace YummyRestaurant.Application.Features.Bookings.Commands.BookingApprove;

public class BookingApproveCommandHandler : IRequestHandler<BookingApproveCommand>
{
    private readonly IGenericRepository<Booking> _repository;

    public BookingApproveCommandHandler(IGenericRepository<Booking> repository)
    {
        _repository = repository;
    }

    public async Task Handle(BookingApproveCommand request, CancellationToken cancellationToken)
    {
        var booking = await _repository.GetByIdAsync(request.Id);
        if (booking != null)
        {
            booking.BookingStatus = BookingStatus.Approved;
            _repository.Update(booking);
        }
    }
}
