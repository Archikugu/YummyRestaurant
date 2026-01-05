using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.BookingDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Bookings.Queries.GetBookingById;

public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, GetByIdBookingDto>
{
    private readonly IGenericRepository<Booking> _repository;
    private readonly IMapper _mapper;

    public GetBookingByIdQueryHandler(IGenericRepository<Booking> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdBookingDto> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdBookingDto>(value);
    }
}
