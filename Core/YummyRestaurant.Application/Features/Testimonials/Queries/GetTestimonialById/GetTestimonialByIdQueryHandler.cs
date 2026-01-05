using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Testimonials.Queries.GetTestimonialById;

public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetByIdTestimonialDto>
{
    private readonly IGenericRepository<Testimonial> _repository;
    private readonly IMapper _mapper;

    public GetTestimonialByIdQueryHandler(IGenericRepository<Testimonial> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdTestimonialDto> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdTestimonialDto>(value);
    }
}
