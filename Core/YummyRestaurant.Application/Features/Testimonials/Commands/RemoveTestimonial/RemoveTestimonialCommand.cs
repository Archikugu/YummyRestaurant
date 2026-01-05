using MediatR;

namespace YummyRestaurant.Application.Features.Testimonials.Commands.RemoveTestimonial;

public class RemoveTestimonialCommand : IRequest
{
    public int Id { get; set; }

    public RemoveTestimonialCommand(int id)
    {
        Id = id;
    }
}
