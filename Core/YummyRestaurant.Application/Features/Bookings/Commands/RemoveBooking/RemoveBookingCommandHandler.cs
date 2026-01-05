using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Bookings.Commands.RemoveBooking;

public class RemoveBookingCommandHandler : IRequestHandler<RemoveBookingCommand>
{
    private readonly IGenericRepository<Booking> _repository;

    public RemoveBookingCommandHandler(IGenericRepository<Booking> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveBookingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        _repository.Remove(value);
    }
}
