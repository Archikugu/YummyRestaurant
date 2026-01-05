using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Testimonials.Commands.CreateTestimonial;

public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
{
    private readonly IGenericRepository<Testimonial> _repository;
    private readonly IMapper _mapper;

    public CreateTestimonialCommandHandler(IGenericRepository<Testimonial> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var testimonial = _mapper.Map<Testimonial>(request.CreateTestimonialDto);
        await _repository.AddAsync(testimonial);
    }
}
