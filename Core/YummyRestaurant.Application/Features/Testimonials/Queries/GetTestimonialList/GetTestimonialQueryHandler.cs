using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Testimonials.Queries.GetTestimonialList;

public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<ResultTestimonialDto>>
{
    private readonly IGenericRepository<Testimonial> _repository;
    private readonly IMapper _mapper;

    public GetTestimonialQueryHandler(IGenericRepository<Testimonial> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultTestimonialDto>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultTestimonialDto>>(values);
    }
}
