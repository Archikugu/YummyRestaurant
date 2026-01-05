using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Testimonials.Commands.RemoveTestimonial;

public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
{
    private readonly IGenericRepository<Testimonial> _repository;

    public RemoveTestimonialCommandHandler(IGenericRepository<Testimonial> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        _repository.Remove(value);
    }
}
