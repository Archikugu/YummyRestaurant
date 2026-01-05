using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.BookingDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Bookings.Queries.GetBookingList;

public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, List<ResultBookingDto>>
{
    private readonly IGenericRepository<Booking> _repository;
    private readonly IMapper _mapper;

    public GetBookingQueryHandler(IGenericRepository<Booking> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultBookingDto>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultBookingDto>>(values);
    }
}
