using MediatR;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;

namespace YummyRestaurant.Application.Features.Testimonials.Commands.UpdateTestimonial;

public class UpdateTestimonialCommand : IRequest
{
    public UpdateTestimonialDto UpdateTestimonialDto { get; set; }

    public UpdateTestimonialCommand(UpdateTestimonialDto updateTestimonialDto)
    {
        UpdateTestimonialDto = updateTestimonialDto;
    }
}
