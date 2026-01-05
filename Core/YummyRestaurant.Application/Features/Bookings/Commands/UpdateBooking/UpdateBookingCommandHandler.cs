using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Bookings.Commands.UpdateBooking;

public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand>
{
    private readonly IGenericRepository<Booking> _repository;
    private readonly IMapper _mapper;

    public UpdateBookingCommandHandler(IGenericRepository<Booking> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = _mapper.Map<Booking>(request.UpdateBookingDto);
        _repository.Update(booking);
        await Task.CompletedTask;
    }
}
