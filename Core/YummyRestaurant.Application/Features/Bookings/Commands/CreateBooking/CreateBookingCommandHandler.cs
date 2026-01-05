using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Bookings.Commands.CreateBooking;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand>
{
    private readonly IGenericRepository<Booking> _repository;
    private readonly IMapper _mapper;

    public CreateBookingCommandHandler(IGenericRepository<Booking> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = _mapper.Map<Booking>(request.CreateBookingDto);
        await _repository.AddAsync(booking);
    }
}
