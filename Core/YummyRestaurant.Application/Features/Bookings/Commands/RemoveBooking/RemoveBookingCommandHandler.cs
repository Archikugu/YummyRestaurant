using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Bookings.Commands.RemoveBooking;

public class RemoveBookingCommandHandler(IGenericRepository<Booking> _repository) : IRequestHandler<RemoveBookingCommand>
{

    public async Task Handle(RemoveBookingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
