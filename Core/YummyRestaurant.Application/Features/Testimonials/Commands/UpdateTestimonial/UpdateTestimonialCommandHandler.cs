using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Testimonials.Commands.UpdateTestimonial;

public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
{
    private readonly IGenericRepository<Testimonial> _repository;
    private readonly IMapper _mapper;

    public UpdateTestimonialCommandHandler(IGenericRepository<Testimonial> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var testimonial = _mapper.Map<Testimonial>(request.UpdateTestimonialDto);
        _repository.Update(testimonial);
        await Task.CompletedTask;
    }
}
