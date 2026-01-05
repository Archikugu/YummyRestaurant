using MediatR;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;

namespace YummyRestaurant.Application.Features.Testimonials.Commands.CreateTestimonial;

public class CreateTestimonialCommand : IRequest
{
    public CreateTestimonialDto CreateTestimonialDto { get; set; }

    public CreateTestimonialCommand(CreateTestimonialDto createTestimonialDto)
    {
        CreateTestimonialDto = createTestimonialDto;
    }
}
